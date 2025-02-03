using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SpringArms : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineFreeLook freeLookVCam;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform playerTransform;

    [Header("Settings Zoom")]
    [SerializeField, Range(0.5f, 3f)] private float speedMultiplier = 1f;
    [SerializeField, Range(20f, 80f)] private float minFOV = 30f;
    [SerializeField, Range(60f, 120f)] private float maxFOV = 90f;
    [SerializeField] private float zoomSpeed = 10f;

    [Header("Settings RotationCam")]
    [SerializeField] private float playerRotationSpeed = 5f; 
    [SerializeField] private float transitionSpeed = 2f;

    private bool isRMBPressed;
    private bool isLMBPressed;
    private bool cameraMovementLock;
    private bool isResetting = false;
    

    private float currentZoom;
    private float targetZoom;

    private void Start()
    {
        inputManager = GameController.Instance.GetComponentManager<InputManager>();
        freeLookVCam = FindObjectOfType<CinemachineFreeLook>();

        targetZoom = freeLookVCam.m_Lens.FieldOfView;

        GameObject obj = GameObject.FindWithTag("Player");
        playerTransform = obj.transform;

        GameObject objCamera = GameObject.FindWithTag("MainCamera");
        mainCamera = objCamera.GetComponent<Camera>();
    }

    private void Update()
    {
        isRMBPressed = (Mouse.current != null) ? Mouse.current.rightButton.isPressed : Input.GetMouseButton(1);
        isLMBPressed = (Mouse.current != null) ? Mouse.current.leftButton.isPressed : Input.GetMouseButton(0);

        Vector2 lookInput = inputManager.delta;

        OnLook(lookInput, true);
        HandleCursorLock();
        HandleZoom();
        HandleRotationPlayerAndCamera(lookInput);
    }

    private void OnLook(Vector2 cameraMovement, bool isDeviceMouse)
    {
        if (cameraMovementLock) return;
        if (isDeviceMouse && !isRMBPressed) return;
        if (isRMBPressed && !isLMBPressed)
        {

            float deviceMultiplier = Time.deltaTime;

            freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * speedMultiplier * deviceMultiplier;
            freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * speedMultiplier * deviceMultiplier;
        }
    }

    private void HandleCursorLock()
    {
        if (isRMBPressed && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            StartCoroutine(DisableMouseForFrame());
        }
        else if (!isRMBPressed && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            freeLookVCam.m_XAxis.m_InputAxisValue = 0f;
            freeLookVCam.m_YAxis.m_InputAxisValue = 0f;
        }
    }

    private void HandleZoom()
    {
        if (!isRMBPressed)
        {
            float scrollInput = Mouse.current.scroll.y.ReadValue();
            targetZoom -= scrollInput * zoomSpeed * Time.deltaTime;
            targetZoom = Mathf.Clamp(targetZoom, minFOV, maxFOV);
            freeLookVCam.m_Lens.FieldOfView = Mathf.Lerp(freeLookVCam.m_Lens.FieldOfView, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }

    private void HandleRotationPlayerAndCamera(Vector2 cameraMovement)
    {
        if (isRMBPressed && isLMBPressed && playerTransform != null)
        {
            
            if (isResetting)
            {
                
                float targetYRotation = playerTransform.eulerAngles.y;

                
                freeLookVCam.m_XAxis.Value = Mathf.LerpAngle(freeLookVCam.m_XAxis.Value, targetYRotation, Time.deltaTime * transitionSpeed);

                
                if (Mathf.Abs(Mathf.DeltaAngle(freeLookVCam.m_XAxis.Value, targetYRotation)) < 0.5f)
                {
                    isResetting = false; 
                }
            }

            
            float deviceMultiplier = Time.deltaTime;
            freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * speedMultiplier * deviceMultiplier;
            freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * speedMultiplier * deviceMultiplier;

            
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0; 

            if (cameraForward != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
                playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, Time.deltaTime * playerRotationSpeed);
            }
        }
        else
        {
            
            isResetting = true;
        }
    }

    private IEnumerator DisableMouseForFrame()
    {
        cameraMovementLock = true;
        yield return new WaitForEndOfFrame();
        cameraMovementLock = false;
    }
}

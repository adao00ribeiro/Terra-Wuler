using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArms : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoomDistance = 2f;
    [SerializeField] private float maxZoomDistance = 10f;
    [SerializeField] private float smoothness = 10f;

    [Header("Spring Arm Settings")]
    [SerializeField] private float springArmLength = 5f;
    [SerializeField] private Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);

    private float currentZoom;
    private float targetZoom;
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    private Transform cameraTransform;
   [SerializeField]private Transform characterTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        currentZoom = springArmLength;
        targetZoom = springArmLength;
        characterTransform = transform.parent.transform;
        UpdateCameraPosition();
    }

    private void Update()
    {
        HandleInput();
        UpdateCameraTransform();
    }

    private void HandleInput()
    {
        bool isRightMousePressed = Input.GetMouseButton(1);
        bool isLeftMousePressed = Input.GetMouseButton(0);

        if (isRightMousePressed)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            
            targetRotation.y += mouseX * rotationSpeed;
            targetRotation.x -= mouseY * rotationSpeed;
            
            targetRotation.x = Mathf.Clamp(targetRotation.x, -60f, 60f);
        }
        
        if (isRightMousePressed && isLeftMousePressed)
        {
            float mouseX = Input.GetAxis("Mouse X");
            characterTransform.Rotate(Vector3.up, mouseX * rotationSpeed);
        }
        
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            targetZoom -= scrollWheel * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoomDistance, maxZoomDistance);
        }
    }

    private void UpdateCameraTransform()
    {
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime * smoothness);
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * smoothness);
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        Vector3 targetPosition = transform.position + targetOffset;
        Vector3 cameraPosition = targetPosition - (rotation * Vector3.forward * currentZoom);
        
        cameraTransform.position = cameraPosition;
        cameraTransform.rotation = rotation;
        cameraTransform.LookAt(targetPosition);
    }
}

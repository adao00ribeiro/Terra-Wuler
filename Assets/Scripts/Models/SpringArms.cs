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
    [SerializeField] private Vector3 targetOffset = new Vector3(0f, 2f, 0f);
    
    private float currentZoom;
    private float targetZoom;
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    private Transform cameraTransform;
    private bool isRotating = false;
    
    private void Start()
    {
        // Initialize camera
        cameraTransform = Camera.main.transform;
        currentZoom = springArmLength;
        targetZoom = springArmLength;
        
        // Set initial position
        UpdateCameraPosition();
    }
    
    private void Update()
    {
        HandleInput();
        UpdateCameraTransform();
    }
    
    private void HandleInput()
    {
        // Right mouse button for rotation
        if (Input.GetMouseButton(1))
        {
            isRotating = true;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            
            targetRotation.y += mouseX * rotationSpeed;
            targetRotation.x -= mouseY * rotationSpeed;
            
            // Clamp vertical rotation to prevent camera flipping
            targetRotation.x = Mathf.Clamp(targetRotation.x, -60f, 60f);
        }
        else
        {
            isRotating = false;
        }
        
        // Mouse wheel for zoom
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            targetZoom -= scrollWheel * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoomDistance, maxZoomDistance);
        }
    }
    
    private void UpdateCameraTransform()
    {
        // Smooth rotation
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime * smoothness);
        
        // Smooth zoom
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * smoothness);
        
        UpdateCameraPosition();
    }
    
    private void UpdateCameraPosition()
    {
        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        
        // Calculate position
        Vector3 targetPosition = transform.position + targetOffset;
        Vector3 cameraPosition = targetPosition - (rotation * Vector3.forward * currentZoom);
        
        // Update camera transform
        cameraTransform.position = cameraPosition;
        cameraTransform.rotation = rotation;
        
        // Make camera look at target
        cameraTransform.LookAt(targetPosition);
    }
}
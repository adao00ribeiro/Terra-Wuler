using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TerraWuler;

namespace TerraWuler
{
    public class Moviment : MonoBehaviour
    {
        [Header("References")]
        Rigidbody rb;
        CinemachineFreeLook freeLookVCam;
        InputManager inputManager;
        [SerializeField] Animator animator;

        [Header("Settings")]
        [SerializeField] float moveSpeed = 6f;
        [SerializeField] float rotationSpeed = 15f;
        [SerializeField] float smoothTime = 0.2f;

        const float ZeroF = 0f;

        Transform mainCam;
        float currentSpeed;
        float velocity;

        private void Start()
        {

            rb = GetComponent<Rigidbody>();
            freeLookVCam = GetComponentInChildren<CinemachineFreeLook>();
            inputManager = GameController.Instance.GetComponentManager<InputManager>();

            animator = GetComponentInChildren<Animator>();

            mainCam = Camera.main.transform;


            freeLookVCam.Follow = transform;
            freeLookVCam.LookAt = transform;


            freeLookVCam.OnTargetObjectWarped(transform, transform.position - freeLookVCam.transform.position - Vector3.forward);
            
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        public void HandleMovement()
        {

            Vector2 moveInput = inputManager.move;
            var movementDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

            
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movementDirection;

            if (adjustedDirection.magnitude > ZeroF)
            {
                HandlesRotation(adjustedDirection);
                HandleRigidbodyMovement(adjustedDirection);
                SmoothSpeed(adjustedDirection.magnitude);
            }
            else
            {
                SmoothSpeed(ZeroF);
            }
            animator.SetBool("IsRun", inputManager.GetMove().x != 0 || inputManager.GetMove().y != 0);
        }


        public void HandleRigidbodyMovement(Vector3 adjustedDirection)
        {

            var adjustedMovement = adjustedDirection * (moveSpeed * Time.deltaTime);

            rb.MovePosition(rb.position + adjustedMovement);
        }


        public void HandlesRotation(Vector3 adjustedDirection)
        {
            var targetRotation = Quaternion.LookRotation(adjustedDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.LookAt(transform.position + adjustedDirection);
        }


        public void SmoothSpeed(float Value)
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, Value, ref velocity, smoothTime);
        }
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Vector3 movement;
    private bool isGrounded;

    float moveHorizontal, moveVertical;

    [SerializeField] float smoothTime = 0.2f;
    private Transform cameraTransform;

    private void Start()
    {

        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 velocity = movement * speed;
        playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.z).normalized;
        
    }


    public void MovementInput(float _moveHorizontal, float _moveVertical)
    {
        moveHorizontal = _moveHorizontal;
        moveVertical = _moveVertical;
        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        movement = transform.TransformDirection(moveDirection).normalized;
    }

    public void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jumpForce, playerRigidbody.velocity.z);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

*/
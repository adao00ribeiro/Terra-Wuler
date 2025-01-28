using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    private float speed = 700f;
    private float jumpForce = 10f;
    private Vector3 movement;
    private bool isGrounded;

    private void Update()
    {
        InputMovement();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            StartCoroutine(SmoothJump());
        }
    }

    private void FixedUpdate()
    {
        PhysicsMoviment();

        //Suavizar a queda do pulo
        if (!isGrounded)
        {
            playerRigidbody.AddForce(Vector3.down * 20f, ForceMode.Acceleration);
        }
    }

    private void InputMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = (transform.right * moveHorizontal) + (transform.forward * moveVertical);
    }

    private void PhysicsMoviment()
    {
        playerRigidbody.AddForce(movement.normalized * speed * Time.fixedDeltaTime);
    }

    private IEnumerator SmoothJump()
    {
        float jumpDuration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            playerRigidbody.AddForce(Vector3.up * (jumpForce / jumpDuration) * Time.fixedDeltaTime, ForceMode.VelocityChange);
            elapsedTime += Time.fixedDeltaTime;
            yield return null;
        }

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

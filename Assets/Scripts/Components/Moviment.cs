using System.Collections;
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
        playerRigidbody.velocity = new Vector3(velocity.x, playerRigidbody.velocity.y, velocity.z);
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


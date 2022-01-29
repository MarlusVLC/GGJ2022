using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;
    private LayerMask groundLayer;
    private float turnSpeed = 21f;
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput; 
       
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
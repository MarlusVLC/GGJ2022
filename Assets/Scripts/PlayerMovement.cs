using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;
    private float turnSpeed = 20f;
    private float moveSpeed = 5f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();        
    }

    private void FixedUpdate()
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

        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.deltaTime);
        rigidbody.MoveRotation(rotation);
    }
}
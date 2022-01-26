using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float velocity = 5f;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        Movement();    
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 

        Vector3 movementVector = new Vector3(horizontalInput * velocity, 0, verticalInput * velocity);
        rigidbody.AddForce(movementVector * (velocity * Time.deltaTime), ForceMode.Impulse);
    }
}

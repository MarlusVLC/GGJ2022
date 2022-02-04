using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;
    private LayerMask groundLayer;
    private float turnSpeed = 20f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private const float moveSpeed = 5f;
    private float currentMoveSpeed;
    private const float jumpForce = 5f;
    private float currentJumpForce;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentMoveSpeed = moveSpeed;
        currentJumpForce = jumpForce;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput; 
       
        if (isWalking)
        {
            animator.SetBool("IsWalking", true);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir.normalized * currentMoveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * currentJumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
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

    public float MoveSpeed
    {
        get => moveSpeed;
    }

    public float JumpForce
    {
        get => jumpForce;
    }

    public float CurrentMoveSpeed => currentMoveSpeed;

    public void MultiplyMoveSpeed(float multiplier) => currentMoveSpeed = multiplier * moveSpeed;

    public float CurrentJumpForce => currentJumpForce;

    public void MultiplyJumpForce(float multiplier) => currentJumpForce = multiplier * jumpForce;
}
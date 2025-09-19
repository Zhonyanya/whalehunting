using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [Header("Movement")]
    private float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool isSubmerged;
    public float waterDrag;
    bool readyToJump;
    //ground check to actually jump normally
    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask ground;
    bool isGrounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    float horizInput;
    float vertInput;


    Vector3 moveDirection;
    public Transform playerOrientation;
    public Transform cameraOrientation;
    Rigidbody rb;

    private void MyInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && isGrounded)
        {
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (Input.GetKey(sprintKey) && isGrounded)
        {
            speed = sprintSpeed;
        }
        else if (isGrounded)
        {
            speed = walkSpeed;
        }
    }


    private void MovePlayer()
    {
        if (!isSubmerged)
        {
            moveDirection = playerOrientation.forward * vertInput + playerOrientation.right * horizInput;

            if (isGrounded)
            {
                rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
            }
            else
            {
                rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);
            }
        }
        else
        {
            moveDirection = cameraOrientation.forward * vertInput + playerOrientation.right * horizInput;
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    void Update()
    {
        //ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.2f, ground);
        MyInput();
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else if (isSubmerged)
        {
            rb.drag = waterDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
}

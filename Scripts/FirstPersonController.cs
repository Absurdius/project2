using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float jumpForce = 5f;
    public float upDownRange = 60f;
    public static bool canMove { get; set; }

    private CharacterController characterController;
    private Vector3 gravityDirection = Vector3.down; // Initial gravity direction
    private float verticalRotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController.radius = 1.0f;
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            HandleMovementInput();
            HandleRotation();
        }
    }

    void HandleMovementInput()
    {
        // Player Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement
        Vector3 moveDirection = CalculateMoveDirection(horizontal, vertical);
        Vector3 moveVelocity = moveDirection * moveSpeed;

        // Apply gravity
        ApplyGravity();

        // Move the character
        characterController.Move(moveVelocity * Time.deltaTime);
    }

    Vector3 CalculateMoveDirection(float horizontal, float vertical)
    {
        // Get the input direction in world space
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);
        inputDirection = transform.TransformDirection(inputDirection);

        // Project the input direction onto the plane perpendicular to gravity
        Vector3 moveDirection = Vector3.ProjectOnPlane(inputDirection, gravityDirection).normalized;

        return moveDirection;
    }
    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player around the y-axis
        transform.Rotate(0, mouseX, 0);

        // Rotate the camera around the x-axis with clamping
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void ApplyGravity()
    {
        // Apply gravity in the current gravity direction
        characterController.Move(gravityDirection * Physics.gravity.magnitude * Time.deltaTime);
    }

    public void setGravityDirection(Vector3 direction)
    {
        gravityDirection = direction;
    }

}

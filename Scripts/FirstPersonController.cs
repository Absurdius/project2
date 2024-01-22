using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0f;
    public float upDownRange = 60.0f;

    private CharacterController characterController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle player movement
        HandleMovement();

        // Handle player rotation
        HandleRotation();
    }

    void HandleMovement()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        // Apply gravity
        speed.y += Physics.gravity.y;

        // Move the character controller
        characterController.Move(transform.TransformDirection(speed) * Time.deltaTime);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player around the y-axis
        transform.Rotate(0, mouseX, 0);

        // Rotate the camera around the x-axis with clamping
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}

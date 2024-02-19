using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PhysicsFirstpersonController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 500f;
    public float jumpForce = 7f;
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0f;
    public float upDownRange = 60.0f;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb.freezeRotation = true; // Prevent rigidbody from rotating due to physics
    }

    void Update()
    {
        // Player Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement and rotation
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveVelocity = moveDirection * speed;

        // Apply force for movement
        rb.AddForce(moveVelocity);

        // Rotation
        HandleRotation();

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


using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GravityRotation : MonoBehaviour, Triggerable
{
    // Rotation speed in degrees per second
    public float originialRotationDuration = 2.0f;

    private float rotationDuration;

    private Vector3 rotationAxis = Vector3.forward;

    private GameObject rotatingObject;

    // Flag to check if rotation is in progress
    private bool isRotating = false;

    private readonly float rotationAmount = 90.0f;

    void Start() {

        rotatingObject = GameObject.FindGameObjectWithTag("Player");
        if(rotatingObject == null) { Debug.LogWarning("Player tagged gameobject not found"); }

        rotationAxis = Vector3.Normalize(transform.up);
        Debug.Log("Rotation axis for " + transform.parent.parent.gameObject.name + " is " + rotationAxis);

    }

    public void Trigger()
    {   
        if (rotatingObject == null) { Debug.LogError("Ritationg object not found"); }
        // Check if rotation is not already in progress
        if (!isRotating)
        {
            rotationDuration = originialRotationDuration;
            RotateGravity();
        }
    }


    void RotateGravity()
    {
        // Set the flag to indicate that rotation is in progress
        isRotating = true;

        // Suspend physics gravity during rotation
        Physics.gravity = Vector3.zero;

        
    }

     void Update()
    {
        if (isRotating) {

            rotationDuration -= Time.deltaTime;
            float rotationStep = rotationAmount * (Time.deltaTime / originialRotationDuration);

            if (rotationDuration < 0.0f)
            {
                // Restore gravity and reset the rotation flag
                Physics.gravity = -9.82f * rotatingObject.transform.up;
                isRotating = false;
                Debug.Log(Physics.gravity);

                rotatingObject.GetComponent<FirstPersonController>().setGravityDirection(-1f * rotatingObject.transform.up);
            }


            // Rotate the additional object along the same axis
            rotatingObject.transform.Rotate(rotationAxis, rotationStep, Space.World);
        }
    }
}


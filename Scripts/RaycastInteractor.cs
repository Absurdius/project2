using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                //Debug.Log("Cast Ray from: " + transform.position.ToString() + " With direction: " + transform.TransformDirection(Vector3.forward));
                //Debug.Log("Hit: " + hit.collider.gameObject.name);
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}

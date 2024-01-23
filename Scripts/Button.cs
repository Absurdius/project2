using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implement the interface in a script
public class Button : MonoBehaviour, Interactable
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void Interact()
    {
        if (animator != null)
        {
            Debug.Log("Play animation");
            animator.SetTrigger("InteractTrigger");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Interactable
{
    private Animator animator;
    public Triggerable triggerable;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
        triggerable = gameObject.GetComponent<Triggerable>();
    }

    public void Interact()
    {
        if (animator != null)
        {
            Debug.Log("Play animation");
            animator.SetTrigger("InteractTrigger");
        }

        if(triggerable != null)
        {
            triggerable.Trigger();
            Debug.Log("Trigger Triggerable");
        }
    }
}
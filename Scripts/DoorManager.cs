using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorManager : MonoBehaviour, Triggerable
{

    public bool isOpen = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(isOpen) { Open();}
        else { Close();}
    }

    public void Open()
    {
        animator.SetBool("isOpen", true);
        Debug.Log("isOpen is set to true.");
    }

    // Method to set isOpen to false
    public void Close()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("isOpen is set to false.");
    }

    public void Trigger()
    {
        if (isOpen) {
            Close();
        } else {
            Open();
        }
        isOpen = !isOpen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private DoorManager door;

    void Start()
    {
        door = gameObject.GetComponent<DoorManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        door.Close();   
    }


}

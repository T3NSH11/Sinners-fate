using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public int doorID;
    public void OnTriggerEnter(Collider other)
    {
        GameEvents.current.DoorTriggerEnter(doorID);
    }

    public void OnTriggerExit(Collider other)
    {
        GameEvents.current.DoorTriggerExit(doorID);
    }
}

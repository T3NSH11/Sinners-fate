using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onDoorwayTriggerEnter;
    public void DoorTriggerEnter(int doorID)
    {
        if (onDoorwayTriggerEnter != null)
            onDoorwayTriggerEnter(doorID);
    }

    public event Action<int> onDoorTriggerExit;
    public void DoorTriggerExit(int doorID)
    {
        if (onDoorTriggerExit != null)
            onDoorTriggerExit(doorID);
    }
}

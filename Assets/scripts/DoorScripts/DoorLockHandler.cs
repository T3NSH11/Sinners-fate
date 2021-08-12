using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockHandler : MonoBehaviour
{
    public GameObject Generator;
    GameObject[] Doors;
    void Start()
    {
        Doors = GameObject.FindGameObjectsWithTag("Door");
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockHandler : MonoBehaviour
{
    public GameObject Generator;
    GameObject[] Doors;
    GameObject[] Doorlights;
    DoorTrigger[] DoorTrigger;
    public Material Greenmat;
    void Start()
    {
        Doors = GameObject.FindGameObjectsWithTag("Door");
        Doorlights = GameObject.FindGameObjectsWithTag("DoorLights");
        
    }

    void Update()
    {
        for (int i = 0; i < Doors.Length; i++)
        {
            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 1 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 0)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 2 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 1)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 3 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 2)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 4 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 3)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
            }
            if (Doors[i].GetComponent<DoorTrigger>().IsUnlocked == true)
            {
                Doorlights[i].GetComponentInChildren<Light>().color = Color.green;
                Doorlights[i].GetComponent<MeshRenderer>().material = Greenmat;
            }
        }
    }
}

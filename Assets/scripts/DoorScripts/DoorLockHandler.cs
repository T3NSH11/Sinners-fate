using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockHandler : MonoBehaviour
{
    public GameObject Generator;
    GameObject[] Doors;
    DoorTrigger[] DoorTrigger;
    void Start()
    {
        Doors = GameObject.FindGameObjectsWithTag("Door");
        
    }

    void Update()
    {
        for (int i = 0; i < Doors.Length; i++)
        {
            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 1 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 1)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
                Doors[i].transform.parent.GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 2 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 2)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
                Doors[i].transform.parent.GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 3 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 3)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
                Doors[i].transform.parent.GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
            }

            if (Doors[i].GetComponent<DoorTrigger>().Doorgroup == 4 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 4)
            {
                Doors[i].GetComponent<DoorTrigger>().IsUnlocked = true;
                Doors[i].transform.parent.GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
            }
        }
    }
}

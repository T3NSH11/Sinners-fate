using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockHandler : MonoBehaviour
{
    public GameObject Generator;
    GameObject[] Doors;
    DoorTrigger[] DoorTrigger;
    public Material Greenmat;
    void Start()
    {
        Doors = GameObject.FindGameObjectsWithTag("Door");
        
    }

    void Update()
    {
        for (int i = 0; i < gameObject.transform.childCount + 1; i++)
        {
            Debug.Log(gameObject.transform.childCount);
            if (transform.GetChild(i).GetComponent<DoorTrigger>().Doorgroup == 1 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 0)
            {
                Debug.Log("running");
                transform.GetChild(i).GetComponent<DoorTrigger>().IsUnlocked = true;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material = Greenmat;
            }

            if (transform.GetChild(i).GetComponent<DoorTrigger>().Doorgroup == 2 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 1)
            {
                Debug.Log("running");
                transform.GetChild(i).GetComponent<DoorTrigger>().IsUnlocked = true;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material = Greenmat;
            }

            if (transform.GetChild(i).GetComponent<DoorTrigger>().Doorgroup == 3 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 2)
            {
                Debug.Log("running");
                transform.GetChild(i).GetComponent<DoorTrigger>().IsUnlocked = true;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material = Greenmat;
            }

            if (transform.GetChild(i).GetComponent<DoorTrigger>().Doorgroup == 4 && Generator.GetComponent<Generator>().NumberOfpowerCells >= 3)
            {
                Debug.Log("running");
                transform.GetChild(i).GetComponent<DoorTrigger>().IsUnlocked = true;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetChild(0).GetComponent<Light>().color = Color.green;
                transform.GetChild(i).transform.parent.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material = Greenmat;
            }
        }
    }
}

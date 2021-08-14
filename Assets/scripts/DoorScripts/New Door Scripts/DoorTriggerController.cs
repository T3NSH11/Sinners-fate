using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    public GameObject door;
    public bool safeLock;

    public void OnTriggerEnter(Collider other)
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + 5);
    }

    public void OnTriggerExit(Collider other)
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - 5);

    }
}

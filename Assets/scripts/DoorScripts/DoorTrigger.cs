using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    public int rotationVal;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            door.transform.rotation = Quaternion.Euler(0, rotationVal, 0);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

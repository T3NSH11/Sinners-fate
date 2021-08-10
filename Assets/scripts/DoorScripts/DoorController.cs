using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int doorID;

    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorOpen;
        GameEvents.current.onDoorTriggerExit += OnDoorClose;
    }

    public void OnDoorOpen(int doorID)
    {
        if(doorID == this.doorID)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5);

    }

    public void OnDoorClose(int doorID)
    {
        if(doorID == this.doorID)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 5);
    }
}

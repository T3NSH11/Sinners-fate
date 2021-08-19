using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehavior : MonoBehaviour
{
    public AudioSource AlarmSound;
    public FieldOfView FOV;
    public float alertmeter;
    public AI_Waypoint_System current_SetPath;
    public int currentPath_NodeID = 0;
    public float speed;
    public float waypointDist = 1.0f;       //set as private once the desired value has been set.
    public float rotationSpeed = 5.0f;
    public string path_Name;
    public Vector3 prevNode_Pos;
    public GameObject[] patrolPaths;
    public DroneState currentstate;
    public bool PlayerDetected;
    public GameObject AlertBar;
    public Vector3 scalechange;
    public GameObject AlertMeter;
    public GameObject Monster;

    void Start()
    {
        FOV = gameObject.GetComponentInChildren<FieldOfView>();
        currentstate = new Follow_Waypoints1();
        current_SetPath = GameObject.Find(path_Name).GetComponent<AI_Waypoint_System>();
        prevNode_Pos = transform.position;
    }

    void Update()
    {
        PlayerDetected = FOV.PlayerDetected;
        currentstate.DroneUpdate(this);
        scalechange = new Vector3(alertmeter, 0.01f, 0.01f);
    }

    public void SwitchState(DroneState droneState)
    {
        currentstate = droneState;
    }
}

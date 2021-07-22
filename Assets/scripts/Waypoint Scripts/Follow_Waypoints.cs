using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Waypoints : MonoBehaviour
{
    public AI_Waypoint_System current_SetPath;
    public int currentPath_NodeID = 0;
    public float speed;
    public float waypointDist = 1.0f;       //set as private once the desired value has been set.
    public float rotationSpeed = 5.0f;
    public string path_Name;

    Vector3 prevNode_Pos;
    Vector3 currentNode_Pos; 

    void Start()
    {
        current_SetPath = GameObject.Find(path_Name).GetComponent<AI_Waypoint_System>();
        prevNode_Pos = transform.position;
    }

    void Update()
    {
        float node_Distance = Vector3.Distance(current_SetPath.pathNodes[currentPath_NodeID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, current_SetPath.pathNodes[currentPath_NodeID].position, Time.deltaTime * speed);

        var object_Rotation = Quaternion.LookRotation(current_SetPath.pathNodes[currentPath_NodeID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, object_Rotation, Time.deltaTime*rotationSpeed);

        if (node_Distance <= waypointDist)
        {
            currentPath_NodeID++;
        }

        if (currentPath_NodeID >= current_SetPath.pathNodes.Count)
        {
            currentPath_NodeID = 0;
        }
    }
}

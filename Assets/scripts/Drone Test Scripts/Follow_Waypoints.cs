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

    public GameObject[] patrolPaths;

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

    public void GetPath()
    {
        int path_ID = Random.Range(0, patrolPaths.Length);      //Set this as random for now.

        transform.position = patrolPaths[path_ID].transform.position;
        Follow_Waypoints currentPath = GetComponent<Follow_Waypoints>();

        /*When we start creating specific cases, where the AI needs to select a specific path, like the path from a vent to an alerted drone,
         we'll set the function to enter a given path name and then pass that into "currentPath.path_Name"*/
        currentPath.path_Name = patrolPaths[path_ID].name;
    }
}

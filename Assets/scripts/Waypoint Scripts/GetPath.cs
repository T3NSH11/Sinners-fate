using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPath : MonoBehaviour
{
    public GameObject[] patrolPaths;
    void Start()
    {
        int path_ID = Random.Range(0, patrolPaths.Length);      //Set this as random for now.

        transform.position = patrolPaths[path_ID].transform.position;
        Follow_Waypoints currentPath = GetComponent<Follow_Waypoints>();

        /*When we start creating specific cases, where the AI needs to select a specific path, like the path from a vent to an alerted drone,
         we'll set the function to enter a given path name and then pass that into "currentPath.path_Name"*/
        currentPath.path_Name = patrolPaths[path_ID].name;
    }
}

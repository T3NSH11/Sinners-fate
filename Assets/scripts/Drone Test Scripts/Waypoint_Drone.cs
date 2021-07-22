using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Drone : MonoBehaviour
{
    public GameObject[] waypoints;
    public int wayPNum = 0;

    public float minDist;
    public float droneSpeed;

    /*Use this bool if you want the Drone to move from waypoints randomly. Don't think it's necessary though. 
    We should let the Drone paths be predictable and let the Monster's be unpredictable*/
    //public bool rand = true;

    public bool patrol = true;      //When false, the drone is either stationary, or should be in Alert Mode.

    void Update()
    {
        float wayPDist = Vector3.Distance(gameObject.transform.position, waypoints[wayPNum].transform.position);

        if (patrol)
        {
            if (wayPDist > minDist)
            {
                Patrol();
            }

            else
            {
                if (wayPNum + 1 == waypoints.Length)
                {
                    wayPNum = 0;
                }

                else
                {
                    wayPNum++;
                }
            }
        }
    }

    public void Patrol()
    {
        gameObject.transform.LookAt(waypoints[wayPNum].transform.position);
        gameObject.transform.position += gameObject.transform.forward * droneSpeed * Time.deltaTime;
    }
}

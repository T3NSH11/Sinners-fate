using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Waypoints1 : DroneState
{
    public override void DroneUpdate(DroneBehavior DroneStateMachine)
    {
        float node_Distance = Vector3.Distance(DroneStateMachine.current_SetPath.pathNodes[DroneStateMachine.currentPath_NodeID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, DroneStateMachine.current_SetPath.pathNodes[DroneStateMachine.currentPath_NodeID].position, Time.deltaTime * DroneStateMachine.speed);

        var object_Rotation = Quaternion.LookRotation(DroneStateMachine.current_SetPath.pathNodes[DroneStateMachine.currentPath_NodeID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, object_Rotation, Time.deltaTime*DroneStateMachine.rotationSpeed);

        if (node_Distance <= DroneStateMachine.waypointDist)
        {
            DroneStateMachine.currentPath_NodeID++;
        }

        if (DroneStateMachine.currentPath_NodeID >= DroneStateMachine.current_SetPath.pathNodes.Count)
        {
            DroneStateMachine.currentPath_NodeID = 0;
        }

        if (DroneStateMachine.PlayerDetected)
        {
            DroneStateMachine.SwitchState(new Scan());
        }
    }
}

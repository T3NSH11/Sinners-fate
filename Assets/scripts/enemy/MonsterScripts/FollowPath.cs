using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        float node_Distance = Vector3.Distance(MonsterState.current_SetPath.pathNodes[MonsterState.currentPath_NodeID].position, MonsterState.transform.position);
        MonsterState.transform.position = Vector3.MoveTowards(MonsterState.transform.position, MonsterState.current_SetPath.pathNodes[MonsterState.currentPath_NodeID].position, Time.deltaTime * MonsterState.speed);

        var object_Rotation = Quaternion.LookRotation(MonsterState.current_SetPath.pathNodes[MonsterState.currentPath_NodeID].position - MonsterState.transform.position);
        MonsterState.transform.rotation = Quaternion.Slerp(MonsterState.transform.rotation, object_Rotation, Time.deltaTime * MonsterState.rotationSpeed);

        if (node_Distance <= MonsterState.waypointDist)
        {
            MonsterState.currentPath_NodeID++;
        }

        if (MonsterState.currentPath_NodeID >= MonsterState.current_SetPath.pathNodes.Count)
        {
            MonsterState.currentPath_NodeID = 0;
        }

        if (MonsterState.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPlayer());
        }
    }
}

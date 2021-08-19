using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        for (int i = 0; i < MonsterState.PathNodes.Length; i++)
        {
            if (MonsterState.PathNodes[i].GetComponent<NodeClass>().DistanceFromPlayer < MonsterState.LeastDistanceToPlayer && MonsterState.PathNodes[i].GetComponent<NodeClass>().Enabled == true)
            {
                MonsterState.LeastDistanceToPlayer = MonsterState.PathNodes[i].GetComponent<NodeClass>().DistanceFromPlayer;
                MonsterState.NearestNode = MonsterState.PathNodes[i];
            }
        }
        
        MonsterState.gameObject.transform.position = MonsterState.NearestNode.transform.position;
        MonsterState.gameObject.transform.rotation = MonsterState.player.transform.rotation;       
        MonsterState.LeastDistanceToPlayer = 9999999;
        MonsterState.teleport = false;
        MonsterState.SwitchState(new FollowPath());
    }
}

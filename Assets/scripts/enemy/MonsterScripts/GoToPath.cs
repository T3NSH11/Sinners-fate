using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPath : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.transform.position = Vector3.MoveTowards(MonsterState.transform.position, MonsterState.PathTargetPos, Time.deltaTime * MonsterState.MonsterSpeed);

     
        if (MonsterState.EnemyCollider.Length != 0)
        {
            MonsterState.Onpath = true;
        }
        else
        {
            MonsterState.Onpath = false;
        }

        if (MonsterState.Onpath)
        {
            MonsterState.gameObject.GetComponentInParent<Follow_Waypoints>().enabled = true;
        }
        else
        {
            MonsterState.gameObject.GetComponentInParent<Follow_Waypoints>().enabled = false;
        }

        if (MonsterState.FOV.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPlayer());
        }
        if (!MonsterState.FOV.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPath());
        }

    }

}

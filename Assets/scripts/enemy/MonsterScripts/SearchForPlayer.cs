using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.monster.transform.position = Vector3.MoveTowards(MonsterState.monster.transform.position, MonsterState.PlayerLostLoc, Time.deltaTime * MonsterState.MonsterSpeed);
        MonsterState.SearchTime += Time.deltaTime;
  
        if (MonsterState.FOV.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPlayer());
        }

        if (MonsterState.SearchTime > 10)
        {
            MonsterState.SwitchState(new GoToPath());
        }

        if (MonsterState.teleport == true)
        {
            MonsterState.SwitchState(new Teleport());
        }

    }
}

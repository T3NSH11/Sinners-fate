using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.transform.position = Vector3.MoveTowards(MonsterState.transform.position, MonsterState.PlayerLostLoc, Time.deltaTime * MonsterState.MonsterSpeed);
  
        if (MonsterState.FOV.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPlayer());
        }

        if (MonsterState.SearchTime > 10)
        {
            MonsterState.SwitchState(new GoToPath());
        }
    }
}

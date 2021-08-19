using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPath : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.monster.transform.position = Vector3.MoveTowards(MonsterState.monster.transform.position, MonsterState.PathTargetObj.transform.position, Time.deltaTime * MonsterState.MonsterSpeed);

        if (MonsterState.FOV.PlayerDetected)
        {
            MonsterState.SwitchState(new FollowPlayer());
        }
        if (MonsterState.Onpath)
        {
            MonsterState.SwitchState(new FollowPath());
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonsterState
{
    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.monster.transform.position = Vector3.MoveTowards(MonsterState.monster.transform.position, MonsterState.FOV.playerObj.transform.position, Time.deltaTime * MonsterState.MonsterSpeed);
        MonsterState.SearchTime = 0;

        if (MonsterState.SearchTime > 10)
        {
            MonsterState.SwitchState(new GoToPath());
        }

        if (Vector3.Distance(MonsterState.monster.transform.position, MonsterState.player.transform.position) < MonsterState.enemyAttackRange)
        {
            MonsterState.SwitchState(new attack());
        }

        if (!MonsterState.FOV.PlayerDetected && MonsterState.SearchTime < 10)
        {
            MonsterState.SwitchState(new SearchForPlayer());

        }
    }
}

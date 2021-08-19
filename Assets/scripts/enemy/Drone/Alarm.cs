using UnityEngine;

public class Alarm : DroneState
{
    
    public override void DroneUpdate(DroneBehavior DroneStateMachine)
    {
        DroneStateMachine.Monster.GetComponent<MonsterStateMachine>().teleport = true;
        DroneStateMachine.AlarmSound.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : DroneState
{
    public override void DroneUpdate(DroneBehavior DroneStateMachine)
    {
        if (DroneStateMachine.PlayerDetected)
        {
            DroneStateMachine.alertmeter += Time.deltaTime; 
        }
        else
        {
            DroneStateMachine.alertmeter -= Time.deltaTime;
        }

        if (DroneStateMachine.alertmeter >= 100)
        {
            DroneStateMachine.SwitchState(new Alarm());
        }

        if (!DroneStateMachine.PlayerDetected)
        {
            DroneStateMachine.SwitchState(new Follow_Waypoints1());
        }
    }
}

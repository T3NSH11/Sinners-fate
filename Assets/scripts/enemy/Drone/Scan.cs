using UnityEngine;

public class Scan : DroneState
{
    public override void DroneUpdate(DroneBehavior DroneStateMachine)
    {
        if (DroneStateMachine.PlayerDetected)
        {
            DroneStateMachine.alertmeter += 0.07f * Time.deltaTime;
            DroneStateMachine.AlertBar.transform.localScale = DroneStateMachine.scalechange;
            DroneStateMachine.AlertMeter.SetActive(true);
        }
        else
        {
            DroneStateMachine.alertmeter -= 0.03f * Time.deltaTime;
            DroneStateMachine.AlertBar.transform.localScale = DroneStateMachine.scalechange;
        }

        if (DroneStateMachine.alertmeter >= 0.15)
        {
            DroneStateMachine.SwitchState(new Alarm());
        }

        if (!DroneStateMachine.PlayerDetected && DroneStateMachine.alertmeter <= 0)
        {
            DroneStateMachine.SwitchState(new Follow_Waypoints1());
            DroneStateMachine.AlertMeter.SetActive(false);
        }
    }
}

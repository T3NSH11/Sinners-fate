using UnityEngine;

public class attack : MonsterState
{

    public override void MonsterUpdate(MonsterStateMachine MonsterState)
    {
        MonsterState.deathui.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}

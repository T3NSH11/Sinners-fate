using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject deathui;
    public GameObject player;
    public float enemyAttackRange;




    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < enemyAttackRange)
        {
            deathui.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            deathui.SetActive(false);
        }
    }
}

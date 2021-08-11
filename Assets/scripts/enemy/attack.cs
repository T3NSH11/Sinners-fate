using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public bool playerInRange;
    public GameObject player;
    public float enemyAttackRange;



    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < enemyAttackRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
}

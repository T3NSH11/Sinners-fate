using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{

    private bool detected;
    private Vector3 directiontoplayer;

    void Start()
    {
        detected = gameObject.GetComponent<FieldOfView>().PlayerDetected;
        directiontoplayer = gameObject.GetComponent<FieldOfView>().directionToPlayer;
    }

    void Update()
    {
        if (detected)
        {
            transform.position = (directiontoplayer);
        }
    }

    void FixedUpdate()
    {
        if (detected)
        {
            
        }
    }
}

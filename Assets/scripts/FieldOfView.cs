using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float RangeRadius;
    [Range(0,360)]
    public float FOVAngle;

    public GameObject playerObj;

    public LayerMask PlayerMask;
    public LayerMask WallMask;

    public bool PlayerDetected;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private void FieldOfViewCheck()
    {
        Collider[] CollidersInRange = Physics.OverlapSphere(transform.position, RangeRadius, PlayerMask);

        if (CollidersInRange.Length != 0)
        {
            Transform PlayerTransform = CollidersInRange[0].transform;
            Vector3 directionToTarget = (PlayerTransform.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < FOVAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, PlayerTransform.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, WallMask))
                    PlayerDetected = true;
                else
                    PlayerDetected = false;
            }
            else
                PlayerDetected = false;
        }
        else if (PlayerDetected)
            PlayerDetected = false;
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
}
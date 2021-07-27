using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    public Vector3 ForceFeildPos;
    public List<Vector3> ObstaclePos;
    public List<Vector3> DirectionsToObstacles;
    public Collider[] ObstacleCollider;
    public float ForceFieldRad = 10;
    public float PushForce = 10;
    public LayerMask ObstacleLayer;
    void Start()
    {
        ObstacleLayer = LayerMask.GetMask("wall");
    }

    void Update()
    {
        ForceFeildPos = gameObject.transform.position;
        ObstacleCollider = Physics.OverlapSphere(ForceFeildPos, ForceFieldRad, ObstacleLayer);


        if (ObstacleCollider.Length > 0)
        {
            for (int i = 0; i < ObstacleCollider.Length; i++)
            {
                ObstaclePos[i] = ObstacleCollider[i].transform.position;
                DirectionsToObstacles[i] = (ObstaclePos[i] - transform.position).normalized;
                gameObject.GetComponent<Rigidbody>().velocity += -DirectionsToObstacles[i] * PushForce;
            }
        }
    }
}

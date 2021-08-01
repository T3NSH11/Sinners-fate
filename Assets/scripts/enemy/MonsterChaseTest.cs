using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
     public GameObject MonsterContainerObj;
    public bool Onpath;
    public Vector3 ContainerPos;
    public Vector3 DirectionToContainer;
    public float SearchTime;
    public Vector3 PlayerLostLoc;
    public Vector3 DirectionToLost;
    public float MonsterSpeed;
    public LayerMask EnemyMask;
    FieldOfView FOV;

    void Start()
    {
        FOV = gameObject.GetComponent<FieldOfView>();
    }

    void Update()
    {
        SearchTime += Time.deltaTime;
        ContainerPos = MonsterContainerObj.transform.position;
        DirectionToContainer = (ContainerPos - transform.position).normalized;
        DirectionToLost = (PlayerLostLoc - transform.position).normalized;
        Collider[] Enemy = Physics.OverlapSphere(ContainerPos, 1, EnemyMask);

        if (FOV.PlayerDetected)
        {
            PlayerLostLoc = FOV.playerObj.transform.position;
            SearchTime = 0;
        }

        if (Enemy.Length != 0)
        {
            Onpath = true;
        }
        else
        {
            Onpath = false;
        }

        if (Onpath)
        {
            gameObject.GetComponentInParent<Follow_Waypoints>().enabled = true;
        }
        else
        {
            gameObject.GetComponentInParent<Follow_Waypoints>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (SearchTime > 10)
        {
            GoToPath();
        }

        if (!FOV.PlayerDetected && SearchTime < 10 && PlayerLostLoc != new Vector3(0f, 0f, 0f))
        {
            SearchForPlayer();
        }

        if (FOV.PlayerDetected)
        {
            FollowPlayer();
        }
    }

    void GoToPath()
    {
        gameObject.GetComponent<Rigidbody>().velocity = DirectionToContainer * MonsterSpeed * Time.deltaTime;
    }

    void FollowPlayer()
    {
        gameObject.GetComponent<Rigidbody>().velocity = FOV.directionToPlayer * MonsterSpeed * Time.deltaTime;
    }

    void SearchForPlayer()
    {
        gameObject.GetComponent<Rigidbody>().velocity = DirectionToLost * MonsterSpeed * Time.deltaTime;
    }
}


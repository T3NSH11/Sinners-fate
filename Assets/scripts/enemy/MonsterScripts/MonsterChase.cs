using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
     public GameObject PathTargetObj;
    public bool Onpath;
    public Vector3 PathTargetPos;
    public float SearchTime;
    public Vector3 PlayerLostLoc;
    public float MonsterSpeed;
    public LayerMask EnemyMask;
    FieldOfView FOV;

    void Start()
    {
        FOV = gameObject.GetComponent<FieldOfView>();
    }

    void Update()
    {
        Debug.Log("following player" + FOV.PlayerDetected);
        SearchTime += Time.deltaTime;
        PathTargetPos = PathTargetObj.transform.position;
        Collider[] Enemy = Physics.OverlapSphere(PathTargetPos, 1, EnemyMask);

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
        transform.position = Vector3.MoveTowards(transform.position, PathTargetPos, Time.deltaTime * MonsterSpeed);
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, FOV.playerObj.transform.position, Time.deltaTime * MonsterSpeed);
          
        SearchTime = 0;
    }

    void SearchForPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerLostLoc, Time.deltaTime * MonsterSpeed);
    }
}


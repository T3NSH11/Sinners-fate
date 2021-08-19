using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : MonoBehaviour
{
    public FieldOfView FOV;
    public AI_Waypoint_System current_SetPath;
    public int currentPath_NodeID = 0;
    public float speed;
    public float waypointDist = 1.0f;
    public float rotationSpeed = 5.0f;
    public string path_Name;
    public Vector3 prevNode_Pos;
    public GameObject[] patrolPaths;
    public MonsterState currentstate;
    public bool PlayerDetected;
    public GameObject PathTargetObj;
    public bool Onpath;
    public Vector3 PathTargetPos;
    public float SearchTime;
    public Vector3 PlayerLostLoc;
    public float MonsterSpeed;
    public LayerMask EnemyMask;
    public GameObject deathui;
    public GameObject player;
    public float enemyAttackRange;
    public Collider[] EnemyCollider;
    public float DistanceToLost;
    public bool teleport;
    public GameObject[] PathNodes;
    public GameObject NearestNode;
    public float LeastDistanceToPlayer;

    void Start()
    {
        PathNodes = GameObject.FindGameObjectsWithTag("PathNode");
        FOV = gameObject.GetComponentInChildren<FieldOfView>();
        currentstate = new FollowPath();
        current_SetPath = GameObject.Find(path_Name).GetComponent<AI_Waypoint_System>();
        prevNode_Pos = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, PathTargetObj.transform.position) == 2)
        {
            Onpath = true;
        }
        else
        {
            Onpath = false;
        }

        EnemyCollider = Physics.OverlapSphere(PathTargetPos, 1, EnemyMask);

        if (FOV.PlayerDetected)
        {
            PlayerLostLoc = FOV.playerObj.transform.position;
            SearchTime = 0;
        }

        PlayerDetected = FOV.PlayerDetected;

        DistanceToLost = Vector3.Distance(gameObject.transform.position, PlayerLostLoc);

        currentstate.MonsterUpdate(this);
    }

    public void SwitchState(MonsterState monsterState)
    {
        currentstate = monsterState;
    }
}

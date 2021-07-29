using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public bool reachedContainer;
    public Vector3 ContainerPos = new Vector3(0, 0, 0);
    public Vector3 DirectionToContainer;
    private Vector3 directiontoplayer;
    public float LostLocExp;
    public Vector3 PlayerLostLoc;
    public Vector3 DirectionToLost;
    public float MonsterSpeed;
    FieldOfView FOV;

    void Start()
    {
        directiontoplayer = gameObject.GetComponent<FieldOfView>().directionToPlayer;       
        FOV = gameObject.GetComponent<FieldOfView>();
    }

    void Update()
    {
        DirectionToContainer = (ContainerPos - transform.position);
        LostLocExp += Time.deltaTime;
        if (FOV.PlayerDetected)
        {
            PlayerLostLoc = FOV.playerObj.transform.position;
            LostLocExp = 0;
            gameObject.GetComponentInParent<Follow_Waypoints>().enabled = false;
        }

        if (PlayerLostLoc != new Vector3(0f, 0f, 0f))
        {
            DirectionToLost = (PlayerLostLoc - transform.position).normalized;
        }

        if (LostLocExp > 5)
        {
            //gameObject.GetComponentInParent<Follow_Waypoints>().enabled = true;
            PlayerLostLoc = new Vector3(0f, 0f, 0f);
            DirectionToLost = new Vector3(0f, 0f, 0f);
            DirectionToContainer = (ContainerPos - transform.position);
        }
    }

    void FixedUpdate()
    {
        if (FOV.PlayerDetected == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = FOV.directionToPlayer * MonsterSpeed * Time.deltaTime;
        }
        
        if (LostLocExp > 5)
        {
            gameObject.GetComponent<Rigidbody>().velocity = DirectionToLost * MonsterSpeed * Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().velocity = DirectionToContainer * MonsterSpeed * Time.deltaTime;
        }
    }
}


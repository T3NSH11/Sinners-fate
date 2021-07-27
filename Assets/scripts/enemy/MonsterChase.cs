using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
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
        LostLocExp += Time.deltaTime;
        if (FOV.PlayerDetected)
        {
            PlayerLostLoc = FOV.playerObj.transform.position;
            LostLocExp = 0;
        }

        if (PlayerLostLoc != new Vector3(0f, 0f, 0f))
        {
            DirectionToLost = (PlayerLostLoc - transform.position).normalized;
        }
        if (LostLocExp > 5)
        {
            PlayerLostLoc = new Vector3(0f, 0f, 0f);
            DirectionToLost = new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        if (FOV.PlayerDetected == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = FOV.directionToPlayer * MonsterSpeed * Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = DirectionToLost * MonsterSpeed * Time.deltaTime;
        }
    }
}


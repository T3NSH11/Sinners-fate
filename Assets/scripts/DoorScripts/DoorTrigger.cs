using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool IsUnlocked;
    public int Doorgroup;
    
    public Animator DoorAnimator;

    void Start()
    {
        DoorAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(IsUnlocked || other.gameObject.tag == "Monster")
        {
            if(Doorgroup != 1 && (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster"))
            {
                DoorAnimator.SetBool("Open", true);
            }
            
            if(Doorgroup == 1 && other.gameObject.tag == "Player")
            {
                DoorAnimator.SetBool("Open", true);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //TODO bug here!
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            DoorAnimator.SetBool("Open", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool IsUnlocked;
    public int Doorgroup;
    
    public Animator DoorAnimator;

    void start()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        IsUnlocked = DoorAnimator.GetBool("IsUnlocked");

        if (DoorAnimator.GetCurrentAnimatorStateInfo(0).IsName("None"))
        {
            DoorAnimator.SetBool("UnTriggered", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(Doorgroup == 1 && (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster") && IsUnlocked == true)
        {
            DoorAnimator.SetBool("Triggered", true);
        }

        if(Doorgroup > 1 && IsUnlocked == true)
        {
            DoorAnimator.SetBool("Triggered", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            DoorAnimator.SetBool("UnTriggered", true);
        }
    }
}

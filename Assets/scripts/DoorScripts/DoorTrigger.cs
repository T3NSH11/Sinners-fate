using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool IsUnlocked;
    public int Doorgroup;
    
    Animator DoorAnimator;

    void start()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        IsUnlocked = DoorAnimator.GetBool("IsUnlocked");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(Doorgroup == 1 && other.gameObject.tag == "Player" && IsUnlocked == true)
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
        DoorAnimator.SetBool("Triggered", false);
    }
}

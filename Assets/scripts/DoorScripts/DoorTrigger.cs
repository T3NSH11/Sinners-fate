using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool IsUnlocked;
    public int Doorgroup;
    public Animator DoorAnimator;
    public AudioSource DoorOpenSound;
    public AudioSource DoorCloseSound;

    void Start()
    {
        DoorAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(IsUnlocked || (other.gameObject.tag == "Monster" && Doorgroup != 5))
        {
            if(Doorgroup != 1 && (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster"))
            {
                DoorAnimator.SetBool("Open", true);
                DoorOpenSound.Play();
            }
            
            if(Doorgroup == 1 && other.gameObject.tag == "Player")
            {
                DoorAnimator.SetBool("Open", true);
                DoorOpenSound.Play();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //TODO bug here!
        if((IsUnlocked && other.gameObject.tag == "Player") || other.gameObject.tag == "Monster")
        {
            DoorAnimator.SetBool("Open", false);
            DoorCloseSound.Play();
        }
    }
}

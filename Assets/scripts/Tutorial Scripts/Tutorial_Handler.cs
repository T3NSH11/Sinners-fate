using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Handler : MonoBehaviour
{
    public int tutorialIndex = 0;

    public GameObject[] tutorial_events;
    public Collider[] event_Colliders;
    public GameObject[] tutorialPrompts;
    public AudioClip[] tutorial_VoiceLines;

    public GameObject Player;
    public AudioSource reception_Speakers;
    //public Camera starter_Cam;
    //public GameObject camera_start;

    public GameObject prop_Flashlight;
    public GameObject flashlight;
    public GameObject data_Pad;

    // Start is called before the first frame update
    void Start()
    {
        //prop_Flashlight = tutorial_events[3];
        //data_Pad = tutorial_events[4];

    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < tutorialIndex; i++)
        {
            if (i == tutorialIndex)
            {
                if(tutorialIndex<=3)
                    tutorial_events[tutorialIndex].SetActive(true);

                //tutorialPrompts[tutorialIndex].SetActive(true);
            }
            else if (i != tutorialIndex)
            {
                //tutorialPrompts[tutorialIndex].SetActive(false);
            }
        }*/
        
        //Event 0
        if (tutorialIndex == 0)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[0];
            //camera_start.SetActive(false);
            Player.SetActive(true);
        }

        //Event 1
        if (tutorialIndex == 1)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[1];
            Debug.Log("Player walked");
        }

        //Event 2
        if (tutorialIndex == 2)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[2];
            Debug.Log("Player walked to the Right Wall");

        }

        //Event 3
        if (tutorialIndex == 3)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[3];
            Debug.Log("Player sprinted to the opposite Wall");


            //Pickup Flashlight
        }

        //Event 4
        if (tutorialIndex == 4)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[4];
            Debug.Log("Picked up Flashlight");
            //Pickup Data-Pad.
        }
        //Event 5 [Final Event]
        if (tutorialIndex == 5)
        {
            //reception_Speakers.clip = tutorial_VoiceLines[5];
            Debug.Log("Picked up Data-Pad");
        }
    }
}

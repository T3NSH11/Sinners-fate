using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Handler : MonoBehaviour
{
    public int tutorialIndex = 0;

    public GameObject[] tutorial_events;
    public GameObject[] tutorialPrompts;
    public AudioClip[] tutorial_VoiceLines;

    public GameObject Player;
    public AudioSource reception_Speakers;

    public GameObject prop_Flashlight;
    public GameObject flashlight;
    public GameObject data_Pad;

    // Start is called before the first frame update
    void Start()
    {
        //prop_Flashlight = tutorial_events[3];
        //data_Pad = tutorial_events[4];
        PlayVoiceLines(0);
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < tutorial_events.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialPrompts[tutorialIndex].SetActive(true);

                if (i == 1)
                    tutorialPrompts[0].SetActive(false);
            }
            

            else if (i != tutorialIndex)
            {
                tutorialPrompts[tutorialIndex].SetActive(false);
            }
        }*/

        //Event 0
        if (tutorialIndex == 0)
        {
            //Player.SetActive(true);
            tutorialPrompts[0].SetActive(true);
        }

        //Event 1
        if (tutorialIndex == 1)
        {
            Debug.Log("Player walked");
            tutorialPrompts[0].SetActive(false);
        }

        //Event 2
        if (tutorialIndex == 2)
        {
            Debug.Log("Player walked to the Right Wall");
            tutorialPrompts[1].SetActive(true);

        }

        //Event 3
        if (tutorialIndex == 3)
        {
            Debug.Log("Player sprinted to the opposite Wall");
            tutorialPrompts[1].SetActive(false);


            //Pickup Flashlight
        }

        //Event 4
        if (tutorialIndex == 4)
        {
            Debug.Log("Picked up Flashlight");
            //Pickup Data-Pad.
        }
    }

    public void PlayVoiceLines(int vl_Index)
    {
        reception_Speakers.clip = tutorial_VoiceLines[vl_Index];
        reception_Speakers.Play();
    }
}


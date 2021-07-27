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

    void Start()
    {
        PlayVoiceLines(0);
    }

    void Update()
    {
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
    }

    public void PlayVoiceLines(int vl_Index)
    {
        reception_Speakers.clip = tutorial_VoiceLines[vl_Index];
        reception_Speakers.Play();
    }
}


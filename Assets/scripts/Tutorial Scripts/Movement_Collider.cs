using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Collider : MonoBehaviour
{
    public Tutorial_Handler tutorial_handler;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tutorial_handler.tutorialIndex++;
        }
        tutorial_handler.PlayVoiceLines(tutorial_handler.tutorialIndex);
        gameObject.SetActive(false);
    }
}

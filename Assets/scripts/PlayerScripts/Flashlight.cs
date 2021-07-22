using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   public bool flashlightOn;
    public GameObject flashLight;

    void Start()
    {
        flashLight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightOn = !flashlightOn;

            if (flashlightOn)
            {
                flashlightActivated();
            }

            if (!flashlightOn)
            {
                flashlightDeactivated();
            }
        }
    }

    void flashlightActivated()
    {
        flashLight.SetActive(true);
    }


    void flashlightDeactivated()
    {
        flashLight.SetActive(false);
    }
}

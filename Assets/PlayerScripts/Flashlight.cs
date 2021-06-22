using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   public bool flashlightOn;
    public GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight.SetActive(false);
        
    }

    // Update is called once per frame
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

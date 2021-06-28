using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject popUp;
    public float Raylength;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,Raylength))
        {
            if (hit.collider.tag == "interactible")
            {
                //do action
                hit.collider.GetComponent<interactibleObj>().Action();
                popUp.SetActive(true);
                Debug.Log("hit");

            }
            else 
            {
                // deactivate pop up
                popUp.SetActive(false);
            }
        }
       
    }
}

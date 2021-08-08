using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject popUp;
    private GameObject pickUpobj;
    public GameObject flashlight;
    public float Raylength;
    private bool isPickup;
    public Transform pickupPlacholder;
    void Update()
    {
        // to stop any further action that has to do with raycasting while an object is picked up
        if (isPickup == true && pickUpobj)
        {
            pickUpobj.transform.rotation = transform.rotation;
            pickUpobj.transform.position = pickupPlacholder.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUpobj.AddComponent<Rigidbody>();
                isPickup = false;
                pickUpobj = null;
                Debug.Log("hi");
                
            }
            return;
        }

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
           

            if(hit.collider.tag == "pickUp")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPickup = true;
                    pickUpobj = hit.collider.gameObject;
                    Rigidbody rb =  hit.collider.GetComponent<Rigidbody>();
                    Destroy(rb);

                }
            }
            if(hit.collider.tag == "powerCore")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPickup = true;
                    pickUpobj = hit.collider.gameObject;
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    Destroy(rb);

                }
               
            }
            if (hit.collider.tag == "flashlight")
            {
                popUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    Destroy(hit.collider.gameObject);
                    flashlight.SetActive(true);
                }
            }
            if (hit.collider.tag != "flashlight" && hit.collider.tag != "interactible")
            {
                popUp.SetActive(false);
            }
        }

    }
}

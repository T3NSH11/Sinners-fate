using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject popUp;
    public float Raylength;
    private bool isPickup;
    private GameObject pickUpobj;
    public Transform pickupPlacholder;
    // Update is called once per frame
    void Update()
    {
        

        // to stop any further action that has to do with raycasting while an object is picked up
        if (isPickup == true && pickUpobj)
        {
            pickUpobj.transform.rotation = transform.rotation;
            pickUpobj.transform.position = pickupPlacholder.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPickup = false;
                pickUpobj.AddComponent<Rigidbody>();
                pickUpobj = null;
                
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
            else 
            {
                // deactivate pop up
                popUp.SetActive(false);
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
        }
       
    }
}

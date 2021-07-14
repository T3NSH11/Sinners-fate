using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    public Material DetectMat;
    Material originalmat;
    private bool detected;
    void Start()
    {
        originalmat = gameObject.GetComponent<MeshRenderer>().material;
        detected = gameObject.transform.parent.GetComponent<FieldOfView>().PlayerDetected;
    }
    void Update()
    {
        if (detected)
        {
            gameObject.GetComponent<MeshRenderer>().material = DetectMat;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = originalmat;
        }
    }
}

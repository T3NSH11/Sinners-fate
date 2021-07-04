using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    public Material DetectMat;
    Material originalmat;
    void Start()
    {
        originalmat = gameObject.GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        if (gameObject.transform.parent.GetComponent<FieldOfView>().PlayerDetected)
        {
            gameObject.GetComponent<MeshRenderer>().material = DetectMat;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = originalmat;
        }
    }
}

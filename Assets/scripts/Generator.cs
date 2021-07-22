using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int NumberOfpowerCells;

    void Start()
    {
        NumberOfpowerCells = 0;
    }

    void Update()
    {
        collectedPowercells();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerCore"))
        {
            NumberOfpowerCells ++;
            Destroy(other.gameObject);
        }
    }

    public void collectedPowercells()
    {
        if (NumberOfpowerCells == 1)
        {
            Destroy(this);
        }
    }
}

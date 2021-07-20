using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int NumberOfpowerCells;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfpowerCells = 0;
    }

    // Update is called once per frame
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

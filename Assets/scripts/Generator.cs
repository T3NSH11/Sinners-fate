using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int NumberOfpowerCells;
    public GameObject gameEndUI;
    public GameObject dropText;

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
        if (other.gameObject.CompareTag("Player"))
        {
            dropText.SetActive(true);
        }

        if (other.gameObject.CompareTag("powerCore"))
        {
            NumberOfpowerCells ++;
            Destroy(other.gameObject);
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dropText.SetActive(false);
        }
    }


    public void collectedPowercells()
    {
        if (NumberOfpowerCells == 4)
        {
            gameEndUI.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int NumberOfpowerCells;
    gameEnd gameEnd;
    public GameObject dropText;

    public List<GameObject> tier1Doors = new List<GameObject>();
    public List<GameObject> tier2Doors = new List<GameObject>();
    public List<GameObject> tier3Doors = new List<GameObject>();
    public List<GameObject> tier4Doors = new List<GameObject>();

    //public Dictionary<int, List<GameObject>> generatorUnlockables = new Dictionary<int, List<GameObject>>();

    void Start()
    {
        NumberOfpowerCells = 0;
        /*
        generatorUnlockables.Add(1, tier1Doors);
        generatorUnlockables.Add(2, tier2Doors);
        generatorUnlockables.Add(3, tier3Doors);
        generatorUnlockables.Add(4, tier4Doors);
        */
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
        if (NumberOfpowerCells == 1)
        {
            // Add intended functionality based on on number of cells collected

            for (int i = 0; i < tier1Doors.Count; i++)
            {
                tier1Doors[i].SetActive(true);
            }
        }
        if (NumberOfpowerCells == 2)
        {
            for (int i = 0; i < tier1Doors.Count; i++)
            {
                tier2Doors[i].SetActive(true);
            }
        }
        if (NumberOfpowerCells == 3)
        {
            for (int i = 0; i < tier1Doors.Count; i++)
            {
                tier3Doors[i].SetActive(true);
            }
        }
        if (NumberOfpowerCells == 4)
        {
            for (int i = 0; i < tier1Doors.Count; i++)
            {
                tier4Doors[i].SetActive(true);
            }
        }
    }
}

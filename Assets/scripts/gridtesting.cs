using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class gridtesting : MonoBehaviour
{
    Grids grid;
    int value;
    private void Start() 
    {
        grid = new Grids(4, 4, 10f, new Vector3(0,0));
    }
 
    private void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) 
        {
            //grid.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition), 20);
            if(Physics.Raycast(ray, out hit))
            {
                grid.SetValue(hit.point, 20);
            }
        }
 
        if (Input.GetMouseButtonDown(1)) 
        {
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(grid.GetValue(hit.point));
            }
        }
    }
}

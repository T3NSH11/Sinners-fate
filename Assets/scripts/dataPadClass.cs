using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPadClass : interactibleObj
{
    public bool Paused;
    public GameObject padText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Action()
    {
        base.Action();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        padText.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        padText.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}

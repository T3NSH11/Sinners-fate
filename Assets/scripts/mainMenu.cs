using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("quiting game");
        Application.Quit();

    }

    public void loadlevel()
    {
        Debug.Log("level Loading");
        SceneManager.LoadScene("build1");
    }
}

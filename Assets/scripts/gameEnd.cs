using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameEnd : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("quiting game");
        Application.Quit();

    }

    public void loadMain()
    {
        Debug.Log("level Loading");
        SceneManager.LoadScene("mainMenu");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

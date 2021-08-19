using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameEnd : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void loadMain()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

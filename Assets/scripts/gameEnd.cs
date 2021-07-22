using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameEnd : MonoBehaviour
{
    public GameObject DeathUi;
    public GameObject gameEndUi;

    public void onDeath()
    {
        DeathUi.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


    public void onGameEnd()
    {
        gameEndUi.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

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

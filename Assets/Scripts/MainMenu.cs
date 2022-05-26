using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool gameRestarted = false;
    //public Timer timerScript;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        gameRestarted = false; //resetting back to false
        //spawnManagerScript.isGameActive = true; //will turn this back on when i make spawnMan prefab so that timer doesn't stop moving

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /*
    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }
    */

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); //goes to the main menu
        gameRestarted = false; //set it back to false
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameRestarted = true;
            //isGameActive = false from spawn manager script?
        }
    }
}

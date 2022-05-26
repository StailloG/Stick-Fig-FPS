using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePauseMenu : MonoBehaviour
{
    public bool gamePaused;

    private void Awake()
    {
        gamePaused = false;
    }

    // Start is called before the first frame update
    void Start()
    { /*
       * Commenting this out helped music from lvl 3 stop playing when pause menu was pressed
       
        GameObject[] escape = GameObject.FindGameObjectsWithTag("Escape");
        if (escape.Length > 1)
        {
            Destroy(this.gameObject);
        }
        */
        DontDestroyOnLoad(this.gameObject); //error on music (will delete) if i comment this out
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
        {
            //escape menu
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(6); //goes to the pause scene
                gamePaused = true;
                Debug.Log("Game is paused");
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        
    }
}

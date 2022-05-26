using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPlayingMusic3 : MonoBehaviour
{
    public EscapePauseMenu escapePauseMenu;

    private void Awake()
    {
        GameObject[] music3 = GameObject.FindGameObjectsWithTag("Music3");
        if (music3.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || escapePauseMenu.gamePaused == true)
        {
            Destroy(this.gameObject);
            Debug.Log("music should stop working");
        }
    }
}

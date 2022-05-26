using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPlayingMusic : MonoBehaviour
{
    public EscapePauseMenu escapePauseMenu;

    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length > 1)
         {
            Destroy(this.gameObject);
         }
        
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || escapePauseMenu.gamePaused == true)
        {
            Destroy(this.gameObject);
        }
    }
}

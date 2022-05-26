using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPlayingMusic4 : MonoBehaviour
{
    public EscapePauseMenu escapePauseMenu;

    private void Awake()
    {
        GameObject[] music4 = GameObject.FindGameObjectsWithTag("Music4");
        if (music4.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5 || escapePauseMenu.gamePaused == true)
        {
            Destroy(this.gameObject);
        }
    }
}

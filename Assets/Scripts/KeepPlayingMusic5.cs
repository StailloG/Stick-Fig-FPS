using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPlayingMusic5 : MonoBehaviour
{
    public EscapePauseMenu escapePauseMenu;

    private void Awake()
    {
        GameObject[] music5 = GameObject.FindGameObjectsWithTag("Music5");
        if (music5.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6 || escapePauseMenu.gamePaused == true || SceneManager.GetActiveScene().buildIndex == 7)
        {
            Destroy(this.gameObject);
        }
    }
}

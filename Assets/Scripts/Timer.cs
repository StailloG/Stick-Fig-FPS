using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for text
using UnityEngine.SceneManagement; //to restart level

public class Timer : MonoBehaviour
{

    public MainMenu mainMenuScript;
    public float currentTime = 0;
    public TextMeshProUGUI timeDisplay;
    public SpawnManager spawnManagerScript;
    //public GameObject[] spawnGameObj; //for timer so spawnMan doesn't delete

    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] timer = GameObject.FindGameObjectsWithTag("Timer");
        if (timer.Length > 1)
        {
            Destroy(this.gameObject); //so more than one timer doesn't form
        }

       
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject); //this makes the timer continue even on pause menu. but with if statement in update, fixes that!

        //pawnGameObj = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManagerScript.isGameActive == true)
        {
            TimerUpdate();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            timerEnd();
        }


        if (spawnManagerScript.isGameActive == false || mainMenuScript.gameRestarted == true || SceneManager.GetActiveScene().buildIndex == 6) //adding scene manager will delete timer
        {
            Destroy(this.gameObject);
        }
    }

    public void TimerUpdate()
    {
        currentTime += Time.deltaTime;
        timeDisplay.text = " " + currentTime.ToString("F2");
        
    }

    public float timerEnd()
    {
        currentTime += 0;
        timeDisplay.text = " " + currentTime.ToString("F2");
        return currentTime;
    }
}

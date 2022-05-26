using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for text
using UnityEngine.SceneManagement; //to restart level
using UnityEngine.UI; //for restart button

public class SpawnManager : MonoBehaviour
{
    //enemy level variables
    public GameObject enemyPrefab; //lvl 1 enemy
    public GameObject zombies2; //lvl 2 enemy
    public GameObject mermaids; //lvl 3 enemy

    //enemy variables
    public int enemyLimit = 0; //= 5;
    public int enemyLimit2 = 0;
    public int enemyLimit3 = 0;
    public int speed; //following player speed
    private int randomRangeX; //instantiate enemy x range
    private int randomRangeZ; //instantiate enemy z range
    public float height = 0.5f; //for zombies to spawn from ground
    public EnemyController enemyControllerScipt;

    //player variables
    public GameObject crumbledPaper; //additional ammo
    public Transform player;

    //game variables
    public TextMeshProUGUI gameOverText; //gameover text
    public bool isGameActive; //to stop game if not active
    //public Timer timerScript;
    public bool spawn;

    private void Awake()
    {
        isGameActive = true; //game is active at start of game
    }

    void Start()
    {
        isGameActive = true; //again just incase
        Debug.Log("Game started");

        //find player in hierarchy
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //level five enemy alien spawn
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StartCoroutine(AlienSpawn());
        }

        //enemy spawn for level 1
        StartCoroutine(EnemyRandomSpawn());

        //additional crumpled paper ammo not in level 1
        StartCoroutine(CrumbledPaperSpawn());
        
}

    public void Update()
    {
        //level 5
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (enemyControllerScipt.spawnManagScript.enemyLimit == 0)
            {
                StartCoroutine(CreditsScene()); //goes to credit scene after defeating alien level 5
            }
        }
    }


    IEnumerator EnemyRandomSpawn()
    {
        while (enemyLimit < 5)
        {
            //spawn enemies range
            randomRangeX = Random.Range(0, 2); //random range for x
            randomRangeZ = Random.Range(2, -4); //random range for z

            Instantiate(enemyPrefab, new Vector3(randomRangeX, height, randomRangeZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyLimit += 1;
        }
        
    }

    //enemy spawn level 2
    public IEnumerator ZombieSpawn()
    {
        while (enemyLimit2 < 5)
        {
            //spawn enemies range
            randomRangeX = Random.Range(-19, -9); //random range for x
            randomRangeZ = Random.Range(-2, 2); //random range for z

            Instantiate(enemyPrefab, new Vector3(randomRangeX, height, randomRangeZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyLimit2 += 1;
        }
    }

    //enemy spawn level 3 part 1
    public IEnumerator MermaidSpawn()
    {
        while (enemyLimit2 < 3)
        {
            //spawn enemies range
            randomRangeX = Random.Range(10, 18); //random range for x
            randomRangeZ = Random.Range(1, 8); //random range for z

            Instantiate(enemyPrefab, new Vector3(randomRangeX, height, randomRangeZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyLimit2 += 1;
        }
    }

    //enemy spawn level 3 part 2
    public IEnumerator MermaidSpawn2()
    {
        while (enemyLimit3 < 3)
        {
            //spawn enemies range
            randomRangeX = Random.Range(28, 33); //random range for x
            randomRangeZ = Random.Range(11, 18); //random range for z

            Instantiate(enemyPrefab, new Vector3(randomRangeX, height, randomRangeZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyLimit3 += 1;
        }
    }

    //enemy spawn level 5
    public IEnumerator AlienSpawn()
    {
        while (enemyLimit < 10)
        {
            //spawn enemies range
            randomRangeX = Random.Range(-2, 20); //random range for x
            randomRangeZ = Random.Range(-11, 0); //random range for z

            Instantiate(enemyPrefab, new Vector3(randomRangeX, height, randomRangeZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyLimit += 1;
        }
    }

    //spawn crumped paper levels 2-5
    public IEnumerator CrumbledPaperSpawn()
    {   
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Level 2");
            int x = Random.Range(-1, 2);
            int z = Random.Range(-5, 0);
            yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));
            Instantiate(crumbledPaper, new Vector3(x, (float)0.5, z), Quaternion.identity);
        }
        //type if statements for different levels & change spawn location
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            int x = Random.Range(4, 10);
            int z = Random.Range(2, 8);
            yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));
            Instantiate(crumbledPaper, new Vector3(x, 1, z), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            int x = Random.Range(3, 19);
            int z = Random.Range(-17, 0);
            yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));
            Instantiate(crumbledPaper, new Vector3(x, 1, z), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            int x = Random.Range(-2, 20);
            int z = Random.Range(-19, 0);
            yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));
            Instantiate(crumbledPaper, new Vector3(x, 1, z), Quaternion.identity);
        }

    }

    public void GameOver()
    {
        isGameActive = false; //game no longer active
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts game
    }

    //level 5 after defeating all the alien enemies
    public IEnumerator CreditsScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(7);
    }
}

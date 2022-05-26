using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public GameObject[] signs;
    public GameObject enemyPrefab; //enemy prefab
    public GameObject[] enemyArray  = new GameObject[5];

    public int enemiesLeft = 5;

    // Start is called before the first frame update
    void Start()
    {
        //enemiesLeft = enemyArray.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        /*
        if (enemyArray[4])
        {
            enemiesLeft = 5;
        }
        else if (enemyArray[3])
        {
            enemiesLeft = 4;
        }
        else if (enemyArray[2])
        {
            enemiesLeft = 3;
        }
        else if (enemyArray[1])
        {
            enemiesLeft = 2;
        }
        else if (enemyArray[0])
        {
            enemiesLeft = 1;
        }
        else
        {
            enemiesLeft = 0;
        }
        */
        
        /*
        if (enemyArray[4])
        {
            signs[0].SetActive(true);
            signs[1].SetActive(false);
            signs[2].SetActive(false);
            signs[3].SetActive(false);
            signs[4].SetActive(false);
            signs[5].SetActive(false);
        }
        else if (enemyArray[3])
        {
            signs[0].SetActive(false);
            signs[1].SetActive(true);
            signs[2].SetActive(false);
            signs[3].SetActive(false);
            signs[4].SetActive(false);
            signs[5].SetActive(false);
        }
        else if (enemyArray[2])
        {
            signs[0].SetActive(false);
            signs[1].SetActive(false);
            signs[2].SetActive(true);
            signs[3].SetActive(false);
            signs[4].SetActive(false);
            signs[5].SetActive(false);
        }
        else if (enemyArray[1])
        {
            signs[0].SetActive(false);
            signs[1].SetActive(false);
            signs[2].SetActive(false);
            signs[3].SetActive(true);
            signs[4].SetActive(false);
            signs[5].SetActive(false);
        }
        else if (enemyArray[0])
        {
            signs[0].SetActive(false);
            signs[1].SetActive(false);
            signs[2].SetActive(false);
            signs[3].SetActive(false);
            signs[4].SetActive(true);
            signs[5].SetActive(false);
        }
        else
        {
            signs[0].SetActive(false);
            signs[1].SetActive(false);
            signs[2].SetActive(false);
            signs[3].SetActive(false);
            signs[4].SetActive(false);
            signs[5].SetActive(true);
            Destroy(gameObject);
        }
        */
    }
}

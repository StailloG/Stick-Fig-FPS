using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoreEnemies : MonoBehaviour
{
    GameObject enemy;
    public int enemyCount = 10;
    public SpawnManager spawnManagScript; //will give 10, need to decrease it in this script or in enemy script
    public EnemyController enemyContrScript;

    // Start is called before the first frame update
    void Start()
    {
         enemy = GameObject.Find("alien(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyContrScript.dead == true)
        {
            enemyCount -= 1;
        }

        if (enemyCount == 0)
        {
            Debug.Log("proceed to end credit");
        }
    }
}

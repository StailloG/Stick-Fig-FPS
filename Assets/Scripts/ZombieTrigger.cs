using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public GameObject zombies2;
    //public MeshRenderer zombieTriggerBox;
    public GameObject zombieTriggerBox;
    public SpawnManager spawnManager; //to call zombies spawn

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie Trigger"))
        {
            StartCoroutine(spawnManager.ZombieSpawn());
            //spawnManager.ZombieSpawn();
            Destroy(zombieTriggerBox);
        }
    }

}

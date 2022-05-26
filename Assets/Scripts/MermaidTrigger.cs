using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidTrigger : MonoBehaviour
{
    public GameObject mermaids2;
    public GameObject mermaidTriggerBox;

    //call spawn manager script to call mermaidSpawn() method
    public SpawnManager spawnManager;

    private void OnTriggerEnter(Collider other)
    {
        //is player collides with Mermaid Trigger gameObject, startCoroutine for mermaidSpawn() method & delete mermaid trigger gameObject
        if (other.gameObject.CompareTag("Mermaid Trigger"))
        {
            StartCoroutine(spawnManager.MermaidSpawn());
            Destroy(mermaidTriggerBox);
        }
    }
}

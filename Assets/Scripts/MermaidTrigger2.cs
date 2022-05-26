using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidTrigger2 : MonoBehaviour
{
    public GameObject mermaids3;
    public GameObject mermaidTriggerBox2;
    public SpawnManager spawnManager; //to call mermaids spawn

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mermaid Trigger 2"))
        {
            StartCoroutine(spawnManager.MermaidSpawn2());
            Destroy(mermaidTriggerBox2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int nextSceneToLoad; //next scene

    void Start()
    {
        //adds one to next scene
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if next level trigger collides with player, load next scene
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneToLoad);

            Destroy(GameObject.FindGameObjectWithTag("Canvas")); //destroy old level's ammo & health canvas
        }
        
    }
}

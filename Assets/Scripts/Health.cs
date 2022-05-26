using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject[] paper;
    public int currentHealth = 4; //size of elements/amount of lives
    private bool dead;

    //calling other script
    public SpawnManager spawnManager;

    //call audio
    public AudioClip healthGainSound;
    public AudioClip healthLossSound;
    private AudioSource playerAudio;
    void Start()
    {
        currentHealth = paper.Length; //set health to length of array (for health images)

        playerAudio = GetComponent<AudioSource>(); //call player audio source
    }

    void Update()
    {
        if (dead == true)
        {
            Debug.Log("Dead, Game Over!!");
            spawnManager.GameOver(); //calling game over from spawn manager
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet")) //if player gets hit by enemy bullet
        {
            if(spawnManager.isGameActive) //& if game is still active
            {
                if(currentHealth == 4)
                {
                    currentHealth = 3;
                    paper[3].SetActive(false); //hide 1/4 of the health
                    playerAudio.PlayOneShot(healthLossSound, 0.3f);
                }
                else if (currentHealth == 3)
                {
                    currentHealth = 2;
                    paper[2].SetActive(false); //hide 2/4 of the health
                    playerAudio.PlayOneShot(healthLossSound, 0.3f);
                }
                else if (currentHealth == 2)
                {
                    currentHealth = 1;
                    paper[1].SetActive(false); //hide 3/4 of the health
                    playerAudio.PlayOneShot(healthLossSound, 0.3f);
                }
                else
                {
                    currentHealth = 0;
                    paper[0].SetActive(false); //hide all 4 images of health
                    playerAudio.PlayOneShot(healthLossSound, 0.3f);
                }
                
                Debug.Log("you lose a life");
            }
            
            if (currentHealth < 1)
            {
                dead = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health")) //if player obtains pencil for health
        {
            if(currentHealth == 3)
            {
                //display an image of health, play gained health sound, destroy pencil
                currentHealth += 1;
                paper[3].SetActive(true);
                playerAudio.PlayOneShot(healthGainSound, 1.0f);
                Destroy(other.gameObject);
                Debug.Log("You gained a life!");
            }
            else if (currentHealth == 2)
            {
                currentHealth += 1;
                paper[2].SetActive(true);
                playerAudio.PlayOneShot(healthGainSound, 1.0f);
                Destroy(other.gameObject);
                Debug.Log("You gained a life!");
            }
            else if (currentHealth == 1)
            {
                currentHealth += 1;
                paper[1].SetActive(true);
                playerAudio.PlayOneShot(healthGainSound, 1.0f);
                Destroy(other.gameObject);
                Debug.Log("You gained a life!");
            }
            else
            {
                Debug.Log("You have enough lives already!");
            }
            
            if (currentHealth > 0)
            {
                dead = false;
            }
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //enemy following player
    public Transform player;
    private int speed;
    public double minDistance;
    public double maxDistance;

    //enemy health
    public bool dead;
    public GameObject[] paper;
    private int life = 3; //amount of lives
    
    //amount of enemies
    public int enemyLimit;

    //enemy throwing bullets to player
    public float distanceFrom;
    private bool isAttacking;
    private int nextFire = 1;
    private int fireRate;
    public GameObject bullet;
    public Transform enemyLooking;

    //audio
    public AudioClip[] shootingSound;
    private AudioSource enemyAudio;
    public AudioClip enemyDeathSound;

    //calling spawn manager script
    public SpawnManager spawnManagScript;

    void Start()
    {
        //enemy health bar
        paper[2].SetActive(true); //full health
        paper[1].SetActive(false);
        paper[0].SetActive(false);

        //find player transformation
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //call enemy shooting audio
        enemyAudio = GetComponent<AudioSource>();

        //enemy firing ammo rate
        fireRate = Random.Range(1, 3);

        //enemy limit is 10 when in level 5
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            spawnManagScript.enemyLimit = 10;
        }
    }

    void Update()
    {
        
        Attacking();

        //to look at player
        transform.LookAt(player);


        if (Vector3.Distance(transform.position, player.position) >= minDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= maxDistance)
            {
                //have enemy take damage
            }
        }

        EnemyDeath();

        //if enemy 20m from player, ATTACK!!
        if (distanceFrom < 20)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }


    //enemy disappear after being hit by bullet
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("collision has happened");
            //Destroy(gameObject);
            if (life == 3) //full health
            {
                life = 2; //got hit
                paper[2].SetActive(false); //no longer full health
                paper[1].SetActive(true); //at 2/3 life
                paper[0].SetActive(false);
            }
            else if (life == 2) //2/3 life
            {
                life = 1;
                paper[2].SetActive(false); 
                paper[1].SetActive(false); 
                paper[0].SetActive(true);
            }
            else
            {
                life = 0;
                paper[0].SetActive(false);
                Destroy(gameObject);
                dead = true;
                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    spawnManagScript.enemyLimit -= 1;
                    if(spawnManagScript.enemyLimit == 0)
                    {
                        Debug.Log("all enemies have been defeated. Can proceed to end credits");
                    }
                }
                    
            }
        }
    }

    private void OnTriggerEnter(Collider other) //don't delete, allows crumpled paper to hit enemies
    {
        if (other.gameObject.CompareTag("Crumpled Paper"))
        {
            Debug.Log("collision has happened");
            //Destroy(gameObject);
            if (life == 3) //full health
            {
                life = 2; //got hit
                paper[2].SetActive(false); //no longer full health
                paper[1].SetActive(true); //at 2/3 life
                paper[0].SetActive(false);
            }
            else if (life == 2) //2/3 life
            {
                life = 1;
                paper[2].SetActive(false);
                paper[1].SetActive(false);
                paper[0].SetActive(true);
            }
            else
            {
                life = 0;
                paper[0].SetActive(false);
                Destroy(gameObject);
                dead = true;
                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    spawnManagScript.enemyLimit -= 1;
                    if (spawnManagScript.enemyLimit == 0)
                    {
                        Debug.Log("all enemies have been defeated. Can proceed to end credits");
                    }
                }
            }
        }
    }

    public void Attacking()
    {
        if (isAttacking) //if enemy is attacking player
        {
            if (Time.time > nextFire) //if time begininning of the time frame is > nextFire (1)
            {
                nextFire = (int)(Time.time + fireRate); //next fire is fireRate (randomRange of 1-3) + time at beginning of time

                GameObject bulletPrefab = Instantiate(bullet, enemyLooking.transform.position, enemyLooking.rotation) as GameObject; //spawn bulletPrefab with gameObject, enemyLookingPosition, & enemyRotation
                Rigidbody bulletRb = bulletPrefab.GetComponent<Rigidbody>(); //create rigidbody for bullet prefab
                bulletRb.AddForce(enemyLooking.forward * 8f, ForceMode.Impulse); //instant force for enemy bullet
                Destroy(bulletPrefab, 0.4f); //destroy after enemy bullet spawned for 0.4 seconds

                //enemy shooting sound
                enemyAudio.clip = shootingSound[Random.Range(0, shootingSound.Length)];
                enemyAudio.PlayOneShot(enemyAudio.clip, 1.0f);
            }
            
        }
        
    }

    public void EnemyDeath()
    {
        //enemy health
        if (dead == true)
        {
            Destroy(gameObject); //destroy enemy
        }

    }
}
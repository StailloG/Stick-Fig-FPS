using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; //to restart level

public class PlayerController : MonoBehaviour
{
    //player movement
    public float speed;
    private float horizontalInput;
    private float verticalInput;
    public CharacterController controller;

    //calling other scripts
    public SpawnManager spawnManager;
    public CrumbledPaper crumpledPaperScript;

    //player shooting (original ammo)
    public GameObject bullet;
    public GameObject CP;
    public Transform playerLooking; //empty game object to have bullet in front of camera
    public AudioClip[] shootingSound;
    private AudioSource playerAudio;
    public TextMeshProUGUI blackAmmoText;
    private int blackAmmoLeft;
    public int clickAmount;

    //player shooting (additional ammo)
    public TextMeshProUGUI CPAmmoText;
    private int CPAmmoLeft;
    public int CPClickAmount;
    public bool CPEnded;

    //for level 5
    public GameObject notes;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>(); //call audio source
        blackAmmoLeft = 30; //ammo to begin with
        CPAmmoLeft = 50; //additional ammo
        CPEnded = true; //additional ammo not obtained
        
    }

    void Update()
    {
        //call horizontal & vertical inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(spawnManager.isGameActive)
        {
            //move horizontal & vertical
            Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

            //mouse movement
            controller.Move(move * speed * Time.deltaTime);


            //shooting for lvl 1
            if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetMouseButtonDown(0))
            {
                if (Input.GetMouseButtonDown(0) && CPEnded == true && crumpledPaperScript.grabbedCP == false)
                {
                    if (clickAmount <= 29)
                    {
                        //add to clickAmount and subtract 1 from ammo amount
                        clickAmount += 1;
                        UpdateScore(1);

                        //shooting out ammo
                        GameObject bulletPrefab = Instantiate(bullet, playerLooking.transform.position, playerLooking.rotation) as GameObject;
                        Rigidbody bulletRb = bulletPrefab.GetComponent<Rigidbody>();
                        bulletRb.AddForce(playerLooking.forward * 10f, ForceMode.Impulse);

                        //play audio sound
                        playerAudio.clip = shootingSound[Random.Range(0, shootingSound.Length)];
                        playerAudio.PlayOneShot(playerAudio.clip, 1.0f);

                        Destroy(bulletPrefab, 0.4f);
                    }
                    else
                    {
                        clickAmount += 0;
                        UpdateScore(0);
                    }

                }
            }

            //shooting for ammo and additional ammo lvls 2-5
            if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
            {
                ShootingBlackAmmo();
                ShootingCPAmmo();
            }
        }
    }

    public void ShootingBlackAmmo()
    {
        //shooting
        if (Input.GetMouseButtonDown(0) && CPEnded == true && crumpledPaperScript.grabbedCP == false)
        {
            if (clickAmount <= 29)
            {
                //add to clickAmount and subtract 1 from ammo display amount
                clickAmount += 1;
                UpdateScore(1);

                //shooting out ammo
                GameObject bulletPrefab = Instantiate(bullet, playerLooking.transform.position, playerLooking.rotation) as GameObject;
                Rigidbody bulletRb = bulletPrefab.GetComponent<Rigidbody>();
                bulletRb.AddForce(playerLooking.forward * 10f, ForceMode.Impulse);

                //play audio sound
                playerAudio.clip = shootingSound[Random.Range(0, shootingSound.Length)];
                playerAudio.PlayOneShot(playerAudio.clip, 1.0f);

                Destroy(bulletPrefab, 0.4f);
            }
            else
            {
                clickAmount += 0;
                UpdateScore(0);
            }

        }
    }

    public void ShootingCPAmmo()
    {
        //shooting crumbled paper (additional ammo)
        if (Input.GetMouseButtonDown(0) && crumpledPaperScript.grabbedCP == true)
        {
            if (CPClickAmount <= 49)
            {
                //add to CPClickAmount, subtract 1 from CPUpdateScore, CPEnded has not ended
                CPClickAmount += 1;
                CPUpdateScore(1);
                CPEnded = false;

                //shooting out additional ammo
                GameObject CPprefab = Instantiate(CP, playerLooking.transform.position, playerLooking.rotation) as GameObject;
                Rigidbody CPrb = CPprefab.GetComponent<Rigidbody>();
                CPrb.AddForce(playerLooking.forward * 10f, ForceMode.Impulse);

                //play audio sound
                playerAudio.clip = shootingSound[Random.Range(0, shootingSound.Length)];
                playerAudio.PlayOneShot(playerAudio.clip, 1.0f);

                Destroy(CPprefab, 0.4f);
            }
            else
            {
                CPEnded = true; //cp has ended
                CPClickAmount += 0;
                CPUpdateScore(0);
            }

        }
    }

    private void UpdateScore(int ammoToSubtract) //display original ammo
    {
        blackAmmoLeft -= ammoToSubtract;
        blackAmmoText.text = " " + blackAmmoLeft;
    }

    private void CPUpdateScore(int CPToSubtract) //display additional ammo
    {
        CPAmmoLeft -= CPToSubtract;
        CPAmmoText.text = " " + CPAmmoLeft;
    }
}

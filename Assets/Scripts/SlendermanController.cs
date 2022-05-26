using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlendermanController : MonoBehaviour
{
    public Transform player;
    public double minDistance;
    public double maxDistance;
    public int speed;
    public int life = 8;
    public bool dead;

    public bool isAttacking;
    private int nextFire = 1;
    private int fireRate;
    public GameObject bullet;
    public Transform enemyLooking;

    private AudioSource enemyAudio;
    public AudioClip enemyDeathSound;
    public AudioClip[] shootingSound;
    public float distanceFrom;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //call enemy audio
        enemyAudio = GetComponent<AudioSource>();

        fireRate = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Attacking();

        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= maxDistance)
            {
                //have enemy take damage
            }
        }

        if (distanceFrom < 20)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    public void Attacking()
    {
        if (isAttacking)
        {
            //Shoot
            if (Time.time > nextFire)
            {
                nextFire = (int)(Time.time + fireRate);

                GameObject bulletPrefab = Instantiate(bullet, enemyLooking.transform.position, enemyLooking.rotation) as GameObject;
                Rigidbody bulletRb = bulletPrefab.GetComponent<Rigidbody>();
                bulletRb.AddForce(enemyLooking.forward * 8f, ForceMode.Impulse);
                Destroy(bulletPrefab, 0.4f);
                //shooting sound
                enemyAudio.clip = shootingSound[Random.Range(0, shootingSound.Length)];
                enemyAudio.PlayOneShot(enemyAudio.clip, 1.0f);
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{   public void OnCollisionEnter(Collision collision)
    {
        //if player ammo collides with  enemy, delete player bullet
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

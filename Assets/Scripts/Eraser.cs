using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public GameObject eraser;
    public GameObject enemy;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Eraser"))
        {
            Destroy(enemy);
        }
    }
}

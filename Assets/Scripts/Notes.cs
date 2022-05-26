using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notes : MonoBehaviour
{
    //variables
    public int notes = 0; //notes to start off with
    public GameObject plank1;
    public GameObject plank2;
    public TextMeshProUGUI noteCounterText;

    void Update()
    {
        noteCounterText.text = notes + " /8 notes collected."; //display how many notes player has collected

        //if player collected all 8 notes, remove planks to proceed to next level
        if (notes == 8)
        {
            plank1.SetActive(false);
            plank2.SetActive(false);
            noteCounterText.text = "An exit has opened.";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //if player collides with note, incriment 1 & destroy note collected
        if (other.gameObject.CompareTag("Note"))
        {
            notes += 1;
            Destroy(other.gameObject);
        }
    }
}

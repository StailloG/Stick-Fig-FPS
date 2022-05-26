using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrumbledPaper : MonoBehaviour
{
    public GameObject crumpledPaperImage;
    public TextMeshProUGUI crumpledPaperText;
    public PlayerController playerControllerScript;
    public bool grabbedCP;

    public void Start()
    {
        grabbedCP = false; //player did not grab additional ammo
        crumpledPaperImage.gameObject.SetActive(false);
        crumpledPaperText.gameObject.SetActive(false);
    }

    public void Update()
    {
        //If player obtains additional crumpled paper ammo, display crumpled paper ammo image & text
        if (playerControllerScript.CPEnded == false)
        {
            crumpledPaperImage.gameObject.SetActive(true);
            crumpledPaperText.gameObject.SetActive(true);
        }
        
        //additional ammo amount only 50 - so if more, crumpled paper ended, hide additional ammo image & text
        if (playerControllerScript.CPClickAmount >= 50)
        {
            grabbedCP = false;
            playerControllerScript.CPEnded = true; //lets player go back to original, black ammo after additional, crumpled paper ammo
            crumpledPaperImage.gameObject.SetActive(false);
            crumpledPaperText.gameObject.SetActive(false);
        }

    }
    public void OnTriggerEnter(Collider other)
    {

        //if player collides/collects additional crumpled paper ammo, display additional crumpled paper image & text
        if (other.gameObject.CompareTag("Crumpled Paper"))
        {
            grabbedCP = true;
            crumpledPaperImage.gameObject.SetActive(true);
            crumpledPaperText.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}

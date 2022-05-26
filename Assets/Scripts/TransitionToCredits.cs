using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToCredits : MonoBehaviour
{
    public Animator animator;


    public void FadeToCredits()
    {
        animator.SetTrigger("Fade_In");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancing : MonoBehaviour
{
    public AnimationClip anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<AnimationClip>();
    }

    // Update is called once per frame
    void Update()
    {
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float speed;
    public float height;

    // Update is called once per frame
    void Update()
    {
        //call position
        Vector3 pos;
        pos = transform.position;

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y; 

        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
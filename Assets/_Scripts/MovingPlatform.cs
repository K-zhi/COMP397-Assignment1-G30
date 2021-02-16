// add as component for platforms that should move side to side
// adjust rightLimit and leftLimit to adjust travel distance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float rightLimit = 6f;
    public float leftLimit = 2f;
    public float speed = 2f;
    private int direction = 1;
    Vector3 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.z < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.down * direction * speed * 0.003f;
        transform.Translate(movement);
    }
}



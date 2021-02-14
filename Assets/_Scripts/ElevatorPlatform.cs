using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public float rightLimit = 1f;
    public float leftLimit = -3f;
    public float speed = 2f;
    private int direction = 1;
    Vector3 movement;

    // Update is called once per frame

    void Update()
    {
        if (transform.position.y > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.forward * direction * speed * 0.003f;
        transform.Translate(movement);
    }
}

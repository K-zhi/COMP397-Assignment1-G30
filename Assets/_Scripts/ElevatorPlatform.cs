// add as component for platforms that should move up and down
// adjust topLimit and bottomLimit to set lift height
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public float topLimit = 1f;
    public float bottomLimit = -3f;
    public float speed = 2f;
    private int direction = 1;
    Vector3 movement;

    // Update is called once per frame

    void Update()
    {
        if (transform.position.y > topLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < bottomLimit)
        {
            direction = 1;
        }
        movement = Vector3.forward * direction * speed * 0.003f;
        transform.Translate(movement);
    }
}

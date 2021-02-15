// this script should be used as a component for the player object
// it detects the tag of colliders and responds accordingly
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text LogCollsiionEnter;
    public Text LogCollisionStay;
    public Text LogCollisionExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWeakness"))
        {
            Debug.Log("Destroy enemy");
            Destroy(other.transform.parent.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            // future versions should remove a health point
            // SceneManager.LoadScene("Menu");
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Collided with trap");
            // future versions should remove a health point
            // SceneManager.LoadScene("Menu");
        }
        if (other.gameObject.CompareTag("Chip"))
        {
            Debug.Log("Collided with chip");
            // future versions should add item to inventory
        }
        if (other.gameObject.CompareTag("Battery"))
        {
            Debug.Log("Collided with battery");
            // future versions should add item to inventory
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Collided with heart");
            // future versions should restore a health point
        }
        if (other.gameObject.CompareTag("Satellite"))
        {
            Debug.Log("Collided with satellie");
            // future versions should allow player to complete the level
        }
        // Debug.Log("Collided with trigger");

    }

}

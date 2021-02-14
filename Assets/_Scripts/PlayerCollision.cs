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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            // SceneManager.LoadScene("Menu");
        }
        if (other.gameObject.CompareTag("EnemyWeakness"))
        {
            Debug.Log("Destroy enemy");
            Destroy(other.gameObject);
        }
        // Debug.Log("Collided with trigger");

    }

}

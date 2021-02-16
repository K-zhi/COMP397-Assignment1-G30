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
    public bool gameOver = false;
    public float restartDelay = 2.0f;
    public GameObject gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWeakness"))
        {
            Debug.Log("Destroy enemy");
            Destroy(other.transform.parent.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            // future versions should remove a health point
            // SceneManager.LoadScene("Menu");
            if(gameOver == false)
            {
                gameOver = true;
                GameOver();
                Debug.Log("Collided with enemy");
            }

        }
        if (other.gameObject.CompareTag("Trap"))
        {
            gameOver = true;
            GameOver();
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

    void GameOver()
    {
        Invoke("Restart", restartDelay);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
    }
}

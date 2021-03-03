// this script should be used as a component for the player object
// it detects the tag of colliders and responds accordingly
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [Header("Health")]
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private int health;
    private const int MAX_HEALTH = 3;

    [Header("Logs")]
    public Text LogCollsiionEnter;
    public Text LogCollisionStay;
    public Text LogCollisionExit;
    
    [Header("Game Over")]
    public float restartDelay = 2.0f;
    public GameObject gameOverScreen;
    
    [Header("Audio")]
    public AudioSource audio;
    public AudioClip enemySquish;
    public AudioClip enemyHit;
    public AudioClip trapHit;
    public AudioClip itemGet;
    public AudioClip levelComplete;
    public AudioClip gameOver;

    public InventorySystem inventory;

    public void setHealth(int newHealth)
    {
        health = newHealth;
    }
    public int getHealth()
    {
        return health;
    }
    
    private void Start()
    {
        health = MAX_HEALTH;
        heart1 = GameObject.Find("Canvas/Hearts/HeartContainer1");
        heart2 = GameObject.Find("Canvas/Hearts/HeartContainer2");
        heart3 = GameObject.Find("Canvas/Hearts/HeartContainer3");
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWeakness"))
        {
            audio.clip = enemySquish;
            audio.Play();
            Debug.Log("Destroy enemy");
            other.gameObject.transform.parent.GetComponent<SlimeBehaviour>().SetDead();
            other.gameObject.transform.parent.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.parent.Find("Body").GetComponent<BoxCollider>().enabled = false;
            // Destroy(other.transform.parent.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            if (health == 0)
            {
                heart1.SetActive(false);
                audio.clip = gameOver;
                audio.Play();
                GameOver();
                Debug.Log("Collided with enemy");
            }
            else
            {
                if (health == 2)
                    heart3.SetActive(false);
                else if (health == 1)
                    heart2.SetActive(false);
                audio.clip = enemyHit;
                audio.Play();
                Debug.Log("Collided with enemy");
            }
        }
        /**
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("Collided with moving platform");
            transform.parent = other.transform;
        }
        */
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            if (health == 0)
            {
                heart1.SetActive(false);
                audio.clip = gameOver;
                audio.Play();
                GameOver();
                Debug.Log("Collided with enemy");
            }
            else
            {
                if (health == 2)
                    heart3.SetActive(false);
                else if (health == 1)
                    heart2.SetActive(false);
                audio.clip = trapHit;
                audio.Play();
                Debug.Log("Collided with trap");
            }
        }
        if (other.gameObject.CompareTag("Chip"))
        {
            audio.clip = itemGet;
            audio.Play();
            inventory.refreshInventory(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Collided with chip");
            // future versions should add item to inventory
        }
        if (other.gameObject.CompareTag("Battery"))
        {
            audio.clip = itemGet;
            audio.Play();
            inventory.refreshInventory(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Collided with battery");
            // future versions should add item to inventory
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            audio.clip = itemGet;
            audio.Play();
            inventory.refreshInventory(other.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Collided with heart");
            // future versions should restore a health point
        }
        if (other.gameObject.CompareTag("Satellite"))
        {
            audio.clip = levelComplete;
            audio.Play();
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

    public void UpdateHealth()
    {
        switch (health)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
    }
}

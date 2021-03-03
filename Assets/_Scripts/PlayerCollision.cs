// this script should be used as a component for the player object
// it detects the tag of colliders and responds accordingly
using Assets._Scripts;
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

    [Header("Items")]
    private ItemBehaviour itemBehaviour;
    private GameObject heartSlot1;
    private GameObject heartSlot2;
    private GameObject heartSlot3;
    private GameObject batterySlot1;
    private GameObject batterySlot2;
    private GameObject batterySlot3;
    private GameObject chipSlot1;
    private GameObject chipSlot2;
    private GameObject chipSlot3;


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
        itemBehaviour = new ItemBehaviour();

        // find inventory slots
        heartSlot1 = GameObject.Find("HeartSlot1");
        heartSlot2 = GameObject.Find("HeartSlot2");
        heartSlot3 = GameObject.Find("HeartSlot3");
        batterySlot1 = GameObject.Find("BatterySlot1");
        batterySlot2 = GameObject.Find("BatterySlot2");
        batterySlot3 = GameObject.Find("BatterySlot3");
        chipSlot1 = GameObject.Find("ChipSlot1");
        chipSlot2 = GameObject.Find("ChipSlot2");
        chipSlot3 = GameObject.Find("ChipSlot3");
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
            // To Do: enable chip collected icon in UI
            Destroy(other.gameObject);
            Debug.Log("Collided with chip");

            // add chip to inventory
            if (!chipSlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                chipSlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            else
            {
                if (!chipSlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                    chipSlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
                else
                    chipSlot3.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Battery"))
        {
            audio.clip = itemGet;
            audio.Play();
            // To Do: enable battery collected icon in UI
            Destroy(other.gameObject);
            Debug.Log("Collided with battery");

            // add battery to inventory
            if (!batterySlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                batterySlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            else
            {
                if (!batterySlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                    batterySlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
                else
                    batterySlot3.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            audio.clip = itemGet;
            audio.Play();
            Destroy(other.gameObject);
            Debug.Log("Collided with heart");
            
            // add heart to inventory
            if (!heartSlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                heartSlot1.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            else
            {
                if (!heartSlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf)
                    heartSlot2.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
                else
                    heartSlot3.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            }
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

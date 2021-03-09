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

    [Header("Level Complete")]
    public GameObject victoryScreen;

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
            GameObject.Find("ChipImage").GetComponent<Image>().enabled = true;
            audio.clip = itemGet;
            audio.Play();
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
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
            GameObject.Find("BatteryImage").GetComponent<Image>().enabled = true;
            audio.clip = itemGet;
            audio.Play();
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
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
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
            Debug.Log("Collided with heart");

            if (heartSlot1 == null)
                Debug.Log("heart slot 1 is null");
            
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
            Debug.Log("Collided with satellie");
            if (GameObject.Find("BatteryImage").GetComponent<Image>().IsActive() && GameObject.Find("ChipImage").GetComponent<Image>().IsActive())
            {
                Victory();
            }
        }
    }

    public void GameOver()
    {
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        audio.clip = gameOver;
        audio.Play();
        Invoke("Restart", restartDelay);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        audio.clip = levelComplete;
        audio.Play();
        Invoke("Restart", restartDelay);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        victoryScreen.SetActive(true);
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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, GameObject.Find("Jammo_Player").GetComponent<PlayerBehaviour>());
        Debug.Log("Saved");
        SaveSystem.SaveItems(GameObject.Find("Items"));
        SaveSystem.SaveEnemies(GameObject.Find("Enemies"));
        GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject.SetActive(true);
        // Debug.Log("ItemParent activeSelf: " + GameObject.Find("ItemParent").activeSelf);
        // Debug.Log("ItemParent name: " + GameObject.Find("ItemParent").name);
        SaveSystem.SaveInventory(GameObject.Find("ItemParent"));
        GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        // load health
        health = data.health;
        UpdateHealth();

        // load position
        Vector3 position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        Debug.Log(data.playerPosition[0] + " " + data.playerPosition[1] + " " + data.playerPosition[2]);
        GameObject player = GameObject.Find("Jammo_Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = position;
        player.GetComponent<CharacterController>().enabled = true;

        // load item history
        GameObject.Find("BatteryImage").GetComponent<Image>().enabled = data.collectedBattery;
        GameObject.Find("ChipImage").GetComponent<Image>().enabled = data.collectedChip;

        // load item states
        ItemData itemData = SaveSystem.LoadItems();

        GameObject items = GameObject.Find("Items");
        for (int i = 0; i < items.gameObject.transform.childCount; i++)
        {
            items.gameObject.transform.GetChild(i).gameObject.SetActive(itemData.itemStates[i]);
        }

        // load enemy states
        EnemyData enemyData = SaveSystem.LoadEnemies();
        
        GameObject enemies = GameObject.Find("Enemies");
        for (int i = 0; i < enemies.gameObject.transform.childCount; i++)
        {
            if (enemyData.enemyStates[i] == true)
            {
                enemies.gameObject.transform.GetChild(i).gameObject.GetComponent<SlimeBehaviour>().SetDead();
            }
        }

        // load inventory states
        InventoryData inventoryData = SaveSystem.LoadInventory();

        GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject.SetActive(true);
        GameObject itemParent = GameObject.Find("ItemParent");
        GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject.SetActive(false);
        for (int i = 0; i < itemParent.gameObject.transform.childCount; i++)
        {
            if (inventoryData.inventoryStates[i] == true)
            {
                itemParent.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
            }
        }

        Debug.Log("Loaded");
    }
}

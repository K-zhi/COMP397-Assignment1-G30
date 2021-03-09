using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int health;
    public bool chipState;
    public bool batteryState;
    public bool enemyState;
    public float[] playerPosition;
    public bool collectedBattery;
    public bool collectedChip;

    public PlayerData(PlayerCollision player, PlayerBehaviour playerBehaviour)
    {
        // health
        health = player.getHealth();
        // position
        playerPosition = new float[3];
        playerPosition[0] = playerBehaviour.transform.position.x;
        playerPosition[1] = playerBehaviour.transform.position.y;
        playerPosition[2] = playerBehaviour.transform.position.z;
        // item history
        collectedBattery = GameObject.Find("BatteryImage").GetComponent<Image>().enabled;
        collectedChip = GameObject.Find("ChipImage").GetComponent<Image>().enabled;
    }
}

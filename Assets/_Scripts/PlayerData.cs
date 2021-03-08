using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public bool chipState;
    public bool batteryState;
    public bool enemyState;

    public PlayerData(PlayerCollision player)
    {
        health = player.getHealth();

    }
}

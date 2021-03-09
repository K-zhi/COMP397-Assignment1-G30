using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyData
{
    public bool[] enemyStates;
    public EnemyData(GameObject enemies)
    {
        enemyStates = new bool[enemies.gameObject.transform.childCount];
        for (int i = 0; i < enemies.gameObject.transform.childCount; i++)
        {
            enemyStates[i] = enemies.gameObject.transform.GetChild(i).gameObject.GetComponent<SlimeBehaviour>().isDead;
        }
    }
}

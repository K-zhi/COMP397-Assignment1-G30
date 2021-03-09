using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemData
{
    public bool[] itemStates;
    public ItemData(GameObject items)
    {
        itemStates = new bool[items.gameObject.transform.childCount];
        for (int i = 0; i < items.gameObject.transform.childCount; i++)
        {
            itemStates[i] = items.gameObject.transform.GetChild(i).gameObject.activeSelf;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryData
{
    public bool[] inventoryStates;
    public InventoryData(GameObject itemParent)
    {
        inventoryStates = new bool[itemParent.gameObject.transform.childCount];
        for (int i = 0; i < itemParent.gameObject.transform.childCount; i++)
        {
            inventoryStates[i] = itemParent.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetChild(0).transform.gameObject.activeSelf;
        }
    }
}

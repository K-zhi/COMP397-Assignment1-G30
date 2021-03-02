using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    #region Singleton
    public static ItemPickUp instance;
    public int inventorySpaceCount = 9;

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallBack;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("error: more than one inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public List<GameObject> items = new List<GameObject>();

    public bool Add(GameObject item)
    {
        if(items.Count >= inventorySpaceCount)
        {
            Debug.Log("Not enough space");
            return false;
        }
        items.Add(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(GameObject item)
    {
        items.Remove(item);
        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}

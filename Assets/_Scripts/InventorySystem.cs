using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{
    public static bool inventory = true;
    public GameObject inventorySys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showHideInventory();
        }
    }

    public void showHideInventory()
    {
        inventory =! inventory;
        inventorySys.SetActive(inventory);
    }

}

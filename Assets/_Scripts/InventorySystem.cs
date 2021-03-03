// this script should be included as a component on the player object
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static bool inventory = false;
    public GameObject inventorySys;
    public Transform panel;

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
        inventory = !inventory;
        inventorySys.SetActive(inventory);
        if (inventory)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

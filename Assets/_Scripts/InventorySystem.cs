// this script should be included as a component on the player object
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static bool inventory = true;
    public GameObject inventorySys;
    public Transform panel;
    public CameraController playerCamera;

    private void Start()
    {
        inventory = !inventory;
        inventorySys.SetActive(inventory);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        inventory = !inventory;
        inventorySys.SetActive(inventory);
        if (inventory)
        {
            playerCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            playerCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

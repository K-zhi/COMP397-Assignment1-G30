using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CameraController playerCamera;

    [Header("Key-mapping")]
    public GameObject keyMappingPanel;
    public static bool isKeymappingActive = true;

    [Header("Inventory system")]
    public GameObject inventorySys;
    public static bool isInventoryActive = true;

    // Start is called before the first frame update
    void Start()
    {
        isInventoryActive = !isInventoryActive;
        inventorySys.SetActive(isInventoryActive);
        isKeymappingActive = !isKeymappingActive;
        keyMappingPanel.SetActive(isKeymappingActive);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isKeymappingActive = !isKeymappingActive;
            keyMappingPanel.SetActive(isKeymappingActive);
            if (isKeymappingActive)
            {
                playerCamera.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                if (!isInventoryActive)
                {
                    playerCamera.enabled = true;
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            showHideInventory();
        }
    }

    public void showHideInventory()
    {
        isInventoryActive = !isInventoryActive;
        inventorySys.SetActive(isInventoryActive);
        if (isInventoryActive)
        {
            playerCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (!isKeymappingActive)
            {
                playerCamera.enabled = true;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

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
    public List<Transform> heartItemIcons;
    public List<Transform> batteryItemIcons;
    public List<Transform> chipItemIcons;

    public GameObject[] goArraySlot;
    public GameObject[] slot;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
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
        inventory = !inventory;
        inventorySys.SetActive(inventory);
    }

    public void refreshInventory(GameObject item)
    {
        //goArraySlot = GameObject.FindGameObjectsWithTag("Slot").OrderBy(s => s.name).ToArray();
        //Debug.Log("collided with:"+item.tag);
        string tag = item.tag;
        //Debug.Log("inventory:" + tag);
        if (tag.Equals("Heart"))
        {
            setSlotActive(heartItemIcons);
        }
        else if (tag.Equals("Battery"))
        {
            setSlotActive(batteryItemIcons);
        }
        else if (tag.Equals("Chip"))
        {
            setSlotActive(chipItemIcons);
        }
    }

    public void setSlotActive(List<Transform> array)
    {
        for (int i = 0; i < 3; i++)
        {
            RectTransform rectTransform = array[i].GetComponent<RectTransform>();
            //Debug.Log(i + "**" + rectTransform.gameObject.activeSelf);
            if (rectTransform.gameObject.activeSelf == false)
            {
                rectTransform.gameObject.SetActive(true);
                break;
            }
        }
    }
}

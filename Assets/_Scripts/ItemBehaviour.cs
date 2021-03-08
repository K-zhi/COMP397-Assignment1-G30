using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets._Scripts
{
    class ItemBehaviour : MonoBehaviour
    {
        public void useInventoryItem()
        {
            Transform itemSlot = transform;
            GameObject itemIcon = itemSlot.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject;

            // using heart
            if (itemSlot.tag == "Heart")
            {
                Debug.Log("Item is heart");
                switch (GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().getHealth())
                {
                    case 1:
                        // add health and use heart
                        GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().setHealth(2);
                        itemIcon.SetActive(false);
                        break;
                    case 2:
                        // add health and use heart
                        GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().setHealth(3);
                        itemIcon.SetActive(false);
                        break;
                    default:
                        break;
                }
                // update health in UI
                GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().UpdateHealth();
            }

            // using battery
            if (itemSlot.tag == "Battery")
            {
                itemIcon.SetActive(false);
            }

            // using chip
            if (itemSlot.tag == "Chip")
            {
                if (!PlayerBehaviour.hasSuperJump)
                {
                    PlayerBehaviour.hasSuperJump = true;
                    Debug.Log("Has super jump: " + PlayerBehaviour.hasSuperJump);
                    itemIcon.SetActive(false);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject item = null;

    [SerializeField]
    private GameObject itemSlot;

    public GameObject Item { get => item; set => item = value; }

    public void AddItemToSlot(GameObject item)
    {
        if (!this.item)
        {
            this.item = item;

            item.transform.position = itemSlot.transform.position;
            item.transform.rotation = itemSlot.transform.rotation;
            item.transform.parent = itemSlot.transform;

            this.transform.root.GetComponent<PlayerController>()?.PlayTakingItemSound();
        }
        else
            Debug.Log("Player's slot is not empty!");
    }

    public void RemoveItemFromSlot()
    {
        this.item = null;
        Debug.Log("Player's slot is empty. Item has been removed!");
    }
}

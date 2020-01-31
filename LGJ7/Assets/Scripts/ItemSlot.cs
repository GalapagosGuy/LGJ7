using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject slot = null;

    public GameObject Slot { get => slot; set => slot = value; }

    public void AddItemToSlot(GameObject item)
    {
        if (!slot)
            slot = item;
        else
            Debug.Log("Player's slot is not empty!");
    }

    public void RemoveItemFromSlot()
    {
        slot = null;
        Debug.Log("Player's slot is empty. Item has been removed!");
    }
}

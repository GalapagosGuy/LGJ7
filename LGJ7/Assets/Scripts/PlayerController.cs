using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSlot))]
public class PlayerController : MonoBehaviour
{
    private InteractableObject interactableObject;
    private ItemSlot itemSlot;

    private void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();
    }

    public void ActivateInteractableObject()
    {
        Debug.Log("Item use");

        if(interactableObject)
            interactableObject.Use(itemSlot);
    }

    public void SetInteractableObject(InteractableObject obj)
    {
        interactableObject = obj;
    }
}

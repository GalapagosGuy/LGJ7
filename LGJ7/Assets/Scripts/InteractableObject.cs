using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSlot))]
public abstract class InteractableObject : MonoBehaviour
{
    protected ItemSlot itemSlot;

    protected virtual void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();
    }

    public abstract void Use(ItemSlot playersItemSlot);
    
}

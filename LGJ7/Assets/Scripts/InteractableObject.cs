using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemSlot))]
public abstract class InteractableObject : MonoBehaviour
{
    protected ItemSlot itemSlot;
    [SerializeField]
    protected Image fillableCircle;

    protected virtual void Awake()
    {

        //fillableCircle.transform.GetComponentInParent<GameObject>().SetActive(true);
        itemSlot = GetComponent<ItemSlot>();
    }

    public abstract void Use(ItemSlot playersItemSlot);
    
}

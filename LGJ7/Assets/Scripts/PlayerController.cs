using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSlot))]
public class PlayerController : MonoBehaviour
{
    private InteractableObject interactableObject;
    private ItemSlot itemSlot;

    private Animator animator;

    private void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();
        animator = GetComponentInChildren<Animator>();
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

    private int attackNumber = 0;

    public void Attack()
    {
        animator.SetInteger("attackNumber", attackNumber % 2);
        animator.SetTrigger("attackTrigger");

        attackNumber++;
    }
}

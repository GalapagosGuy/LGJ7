using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemSlot))]
public class PlayerController : Character
{
    private InteractableObject interactableObject;
    [SerializeField]
    private int healthRegen = 5;
    private ItemSlot itemSlot;

    private Animator animator;

    protected override void Awake()
    {
        base.Awake();

        itemSlot = GetComponent<ItemSlot>();
        animator = GetComponentInChildren<Animator>();
       
        InvokeRepeating("RegenerateHealth", 0, 5);

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
        if(GetComponentInChildren<Weapon>())
            GetComponentInChildren<Weapon>().Reset();

        animator.SetInteger("attackNumber", attackNumber % 2);
        animator.SetTrigger("attackTrigger");

        attackNumber++;
    }

    private void RegenerateHealth()
    {
        AddHealth(healthRegen);
    }
}

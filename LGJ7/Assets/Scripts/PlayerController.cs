using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemSlot))]
public class PlayerController : Character
{
    private InteractableObject interactableObject;
    [SerializeField]
    private int healthRegen = 5;

    [SerializeField]
    private Text recipeText;

    private bool firstTime = true;
    private ItemSlot itemSlot;

    private Animator animator;

    protected override void Awake()
    {
        base.Awake();

        itemSlot = GetComponent<ItemSlot>();
        animator = GetComponentInChildren<Animator>();
       
        InvokeRepeating("RegenerateHealth", 0, 5);

    }
     
    private void Update()
    {
        if (itemSlot.Item != null)
        {
            firstTime = false;
            recipeText.transform.parent.gameObject.SetActive(true);
            recipeText.text = itemSlot.Item.GetComponent<Item>().GetNextRecipe();
        }
        else if (!firstTime)
        {
            recipeText.transform.parent.gameObject.SetActive(false);
        }
    }

    public void ActivateInteractableObject()
    {

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

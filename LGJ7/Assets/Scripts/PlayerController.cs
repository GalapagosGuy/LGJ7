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

    [SerializeField]
    private AudioSource audiosourcePlayer;

    [SerializeField]
    private AudioClip takingObjectSound;

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
        if(this.transform.position.y > 0.05)
        {
            this.transform.position = new Vector3(transform.position.x, 0.04f, transform.position.z);
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

    public InteractableObject InteractableObject { get => interactableObject;  }

    public override void CheckDeathCondition()
    {
        if (health <= 0)
        {
            audioSource.clip = deathSound;
            audioSource.Play();


            Destroy(Instantiate(puffEffect, transform.position, transform.rotation), 2f);
            this.gameObject.SetActive(false);
        }
    }

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

    public void PlayTakingItemSound()
    {
        audiosourcePlayer.clip = takingObjectSound;
        audiosourcePlayer.Play();
    }

  
}

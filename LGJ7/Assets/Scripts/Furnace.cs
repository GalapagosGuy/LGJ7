using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : InteractableObject
{
    [SerializeField]
    private int heatLevel = 0;

    [SerializeField]
    private int minimumHeat = 10;

    [SerializeField]
    private int maxHeatLevel = 20;

    private void Start()
    {
        InvokeRepeating("DecreaseHeatLevel", 0, 1);
    }


    private float time = 0;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>().IsBroken)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();

        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>().IsHeated)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }

    }

    void Update()
    {
        if(itemSlot.Item != null && !itemSlot.Item.GetComponent<Sword>().IsHeated )
        {
            Heating();
        }
    }

    private void Heating()
    {     
        if(itemSlot.Item.GetComponent<Sword>().TimeToHeat > time && heatLevel >= minimumHeat)
        {
            time += Time.deltaTime;
        }
        else if (itemSlot.Item.GetComponent<Sword>().TimeToHeat <= time)
        {
            itemSlot.Item.GetComponent<Sword>().Preheat();
            itemSlot.Item.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }

    public void PreheatFurnace()
    {
        heatLevel += 5;

        if (heatLevel > maxHeatLevel)
            heatLevel = maxHeatLevel;
    }

    public void DecreaseHeatLevel()
    {
        heatLevel--;

        if (heatLevel < 0)
            heatLevel = 0;
    }
    
}

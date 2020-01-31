using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : InteractableObject
{
    private float time = 0;
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !playersItemSlot.Item.GetComponent<Sword>().IsHeated)
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
        
        if(itemSlot.Item.GetComponent<Sword>().TimeToHeat > time)
        {
            time += Time.deltaTime;
        }
        else
        {
            itemSlot.Item.GetComponent<Sword>().Preheat();
            itemSlot.Item.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }
    
}

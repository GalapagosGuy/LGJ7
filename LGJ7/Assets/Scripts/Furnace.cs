using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : InteractableObject
{

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();

            startHeating();
        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>().IsHeated)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }

    }
    void Update()
    {
        
    }
    private void startHeating()
    {

    }
    
}

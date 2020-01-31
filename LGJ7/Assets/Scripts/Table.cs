﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : InteractableObject
{
    public override void Use(ItemSlot playersItemSlot)
    {
        if(playersItemSlot.Item)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();
        }
        else if(!playersItemSlot.Item)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }
    }
}

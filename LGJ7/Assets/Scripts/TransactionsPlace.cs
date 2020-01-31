using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionsPlace : InteractableObject
{
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>() 
            && playersItemSlot.Item.GetComponent<Sword>().IsReady)
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionsPlace : InteractableObject
{
    [SerializeField]
    private GameManager gameManager;
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>() 
            && playersItemSlot.Item.GetComponent<Sword>().IsReady)
        {
            gameManager.AddGeld(100);
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();
        }
    }
}

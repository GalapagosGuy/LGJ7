using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionsPlace : InteractableObject
{
    [SerializeField]
    private GameManager gameManager;
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Item>() 
            && playersItemSlot.Item.GetComponent<Item>().IsReady)
        {
            if(playersItemSlot.Item.GetComponent<Item>().Type == ITEMTYPE.Sword)
                gameManager.AddGeld(100);
            else if(playersItemSlot.Item.GetComponent<Item>().Type == ITEMTYPE.Axe)
                gameManager.AddGeld(200);

            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();
        }
    }
}

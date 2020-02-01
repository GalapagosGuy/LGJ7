using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodContainer : InteractableObject
{
    [SerializeField]
    private GameObject wood;

    public override void Use(ItemSlot playersItemSlot)
    {
        //if player has ore in hands put it in container
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Wood>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();
        }
        //if player has empty hands give him ore
        else if (!playersItemSlot.Item)
        {
            playersItemSlot.AddItemToSlot(Instantiate(wood, transform.position, Quaternion.identity));
        }
    }
}

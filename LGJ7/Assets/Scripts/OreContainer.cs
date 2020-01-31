using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreContainer : InteractableObject
{
    [SerializeField]
    private GameObject ore;

    public override void Use(ItemSlot playersItemSlot)
    {
        //if player has ore in hands put it in container
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Ore>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();
        }
        //if player has empty hands give him ore
        else if (!playersItemSlot.Item)
        {
            playersItemSlot.AddItemToSlot(Instantiate(ore, transform.position, Quaternion.identity));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : InteractableObject
{

    [SerializeField]
    private GameObject water;

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
            playersItemSlot.AddItemToSlot(Instantiate(water, transform.position, Quaternion.identity));
        }
    }

}

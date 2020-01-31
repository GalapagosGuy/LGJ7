using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : InteractableObject
{
    [SerializeField]
    private int requiredOres = 0;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>() 
            && playersItemSlot.Item.GetComponent<Sword>().IsHeated)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();

            //Forge();
            requiredOres = itemSlot.Item.GetComponent<Sword>().RequiredOres;
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Ore>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            requiredOres--;

            if (requiredOres == 0)
                Forge();
        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>().IsForged)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }
    }

    private void Forge()
    {
        itemSlot.Item.GetComponent<Sword>().Forge();
    }
}

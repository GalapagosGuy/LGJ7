using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : InteractableObject
{
    private float time = 0;
    private float timeOfChilling = 2;
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Sword>().IsForged)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();

        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>() && itemSlot.Item.GetComponent<Sword>().IsChilled)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }

    }
    void Update()
    {
        if (itemSlot.Item != null && !itemSlot.Item.GetComponent<Sword>().IsChilled)
        {
            Chilling();
        }
    }
    private void Chilling()
    {

        if (timeOfChilling > time)
        {
            time += Time.deltaTime;
        }
        else
        {
            itemSlot.Item.GetComponent<Sword>().Chill();
            itemSlot.Item.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            time = 0;
        }
    }

}

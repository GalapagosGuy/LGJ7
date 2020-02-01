using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantTable : InteractableObject
{
    [SerializeField]
    private int requiredWoods = 0;

    [SerializeField]
    private ParticleSystem tinyExplosion;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Item>()
            && playersItemSlot.Item.GetComponent<Item>().IsChilled)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            itemSlot.Item.transform.localScale = new Vector3(1, 1, 1);

            playersItemSlot.RemoveItemFromSlot();

            requiredWoods = itemSlot.Item.GetComponent<Item>().RequiredWoods;
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Wood>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            requiredWoods--;

            if (requiredWoods == 0)
                StartMiniGame();
        }
        else if (!playersItemSlot.Item && itemSlot.Item && itemSlot.Item.GetComponent<Item>() && itemSlot.Item.GetComponent<Item>().IsWoodEnchanted)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);
            itemSlot.Item.GetComponentInChildren<ItemClock>().transform.GetChild(0).gameObject.SetActive(false);
            itemSlot.RemoveItemFromSlot();
        }
    }

    private void Enchant()
    {
        itemSlot.Item.GetComponent<Item>().Enchant();
    }

    private void StartMiniGame()
    {
        Enchant();
    }
}

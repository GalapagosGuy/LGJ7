using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeBag : InteractableObject
{
    private Furnace furnance;

    protected override void Awake()
    {
        base.Awake();
        furnance = GetComponentInParent<Furnace>();
    }

    public override void Use(ItemSlot playersItemSlot)
    {
        furnance?.PreheatFurnace();
    }
}

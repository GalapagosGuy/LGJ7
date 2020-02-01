using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Weapon
{
    [SerializeField]
    private ITEMTYPE type;

    public ITEMTYPE Type { get => type; }
}

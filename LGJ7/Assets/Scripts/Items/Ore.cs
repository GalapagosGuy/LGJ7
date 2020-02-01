using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : Item
{
    public override string GetNextRecipe()
    {
        return "Ore is used to repair damaged weapon on the anvil. Can be also a deadly weapon.";
    }
}

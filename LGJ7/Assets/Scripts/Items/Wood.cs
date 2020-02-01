using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    public override string GetNextRecipe()
    {
        return "Good quality oak wood. Used to repair items on the workstation.";
    }
}

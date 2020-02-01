using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Item
{
    public override string GetNextRecipe()
    {
        if (Random.Range(0, 1) == 0)
            return "This small water cup can hold up to 1m^3 of liquid. Used to fill up buckets.";
        else return "Martial weapon against any greenskin. Used to fill up buckets.";
    }
}

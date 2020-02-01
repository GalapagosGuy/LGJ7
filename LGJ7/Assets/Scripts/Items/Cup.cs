using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Item
{
    private int number;
    
    public override string GetNextRecipe()
    {
        return "This small water cup can hold up to 1m^3 of liquid. Used to fill up buckets.";
        //else return "Martial weapon against any greenskin. Used to fill up buckets.";
    }
}

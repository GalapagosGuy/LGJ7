using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    [SerializeField]
    private GameObject fireParticles;

    /*private void Start()
    {
        GameObject brokenSword = Instantiate(brokenAxes[Random.Range(0, brokenAxes.Count)], transform.position, transform.rotation);

        brokenSword.transform.parent = this.transform.GetChild(0);

        brokenSword.transform.localScale = new Vector3(1, 1, 1);
    }*/

    /*public void SetModelToRepaired()
    {
        Destroy(this.transform.GetChild(0).GetChild(0).gameObject);

        GameObject repairedSwordInst = Instantiate(repai, transform.position, transform.rotation);

        repairedSwordInst.transform.parent = this.transform.GetChild(0);

        repairedSwordInst.transform.localScale = new Vector3(1, 1, 1);
    }*/
    public override string GetNextRecipe()
    {
        if (isBroken)
        {
            nextRecipe = "Fire up your axe in the furnace.";
        }
        if (isHeated)
        {
            nextRecipe = "Go to the anvil, add " + requiredOres + " ores and hammer the axe.";
        }
        if (isForged)
        {
            nextRecipe = "Go to the bucket and chill your axe.";
        }
        if (isChilled)
        {
            nextRecipe = "Go to workstation, add " + RequiredWoods + " woods and connect them to axe.";
        }
        if (isReady)
        {
            nextRecipe = "Give the perfect axe to the customer.";
        }
        return nextRecipe;
    }
    public override void Preheat()
    {
        base.Preheat();
        fireParticles.SetActive(true);
        /*
        isBroken = false;
        isHeated = true;
        fireParticles.SetActive(true);
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;

        damage += 10;*/
    }

    public override void Forge()
    {
        base.Forge();
        fireParticles.SetActive(false);
        /*
        isHeated = false;
        isForged = true;
        GetComponentInChildren<MeshRenderer>().material.color = new Color(0.4f, 0, 0);

        damage += 10;*/
    }

    /*public void Chill()
    {
        isForged = false;
        isChilled = true;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        damage += 10;
    }*/

    public override void Enchant()
    {
        base.Enchant();
        isReady = true;
        /*isChilled = false;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        isReady = true;

        damage += 10;*/
    }
}

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
        return "Same as sword + workstation with 2 woods needed";
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

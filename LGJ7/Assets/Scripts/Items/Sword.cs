using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : Item
{
    
    [SerializeField]
    private List<GameObject> brokenSwords = new List<GameObject>();

    [SerializeField]
    private GameObject repairedSword;

    [SerializeField]
    private GameObject fireParticles;

    private void Start()
    {
        GameObject brokenSword = Instantiate(brokenSwords[Random.Range(0, brokenSwords.Count)], transform.position, transform.rotation);

        brokenSword.transform.parent = this.transform.GetChild(0);

        brokenSword.transform.localScale = new Vector3(1,1,1);
    }
    
    public override string GetNextRecipe()
    {
        if (isBroken)
        {
            nextRecipe = "Preheat your sword in the furnace.";
        }
        if (isHeated)
        {
            nextRecipe = "Go to the anvil, add " + requiredOres + " ores and hammer the sword.";
        }
        if (isForged)
        {
            nextRecipe = "Go to the bucket and chill your sword.";
        }
        if (isReady)
        {
            nextRecipe = "Give the freshed sword to the customer.";
        }
        return nextRecipe;
    }
    public void SetModelToRepaired()
    {
        Destroy(this.transform.GetChild(0).GetChild(0).gameObject);

        GameObject repairedSwordInst = Instantiate(repairedSword, transform.position, transform.rotation);

        repairedSwordInst.transform.parent = this.transform.GetChild(0);

        repairedSwordInst.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void Preheat()
    {
        base.Preheat();
        fireParticles.SetActive(true);
        /*isBroken = false;
        isHeated = true;
        fireParticles.SetActive(true);
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;

        damage += 10;*/
    }

    public override void Forge()
    {
        base.Forge();
        fireParticles.SetActive(false); 
        /*fireParticles.SetActive(false);
        isHeated = false;
        isForged = true;
        GetComponentInChildren<MeshRenderer>().material.color = new Color(0.4f, 0, 0);

        damage += 10;*/
    }

    public override void Chill()
    {
        base.Chill();
        isReady = true;
        /*isForged = false;
        isChilled = true;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        isReady = true;
        
        damage += 10;*/
    }
}

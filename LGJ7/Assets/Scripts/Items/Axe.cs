using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    [SerializeField]
    private bool isBroken = true;
    [SerializeField]
    private bool isHeated = false;
    [SerializeField]
    private bool isForged = false;
    [SerializeField]
    private bool isChilled = false;
    [SerializeField]
    private bool isWoodEnchanted = false;
    [SerializeField]
    private bool isReady = false;
    [SerializeField]
    private int requiredOres = 3;
    private int timeToHeat = 10;

    [SerializeField]
    private List<GameObject> brokenAxes = new List<GameObject>();

    [SerializeField]
    private GameObject repairedAxe;

    public bool IsBroken { get => isBroken; }
    public bool IsHeated { get => isHeated; }
    public bool IsForged { get => isForged; }
    public bool IsChilled { get => isChilled; }
    public bool IsReady { get => isReady; }
    public int RequiredOres { get => requiredOres; }
    public int TimeToHeat { get => timeToHeat; }
    public bool IsWoodEnchanted { get => isWoodEnchanted; set => isWoodEnchanted = value; }

    [SerializeField]
    private GameObject fireParticles;

    private void Start()
    {
        GameObject brokenSword = Instantiate(brokenAxes[Random.Range(0, brokenAxes.Count)], transform.position, transform.rotation);

        brokenSword.transform.parent = this.transform.GetChild(0);

        brokenSword.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetModelToRepaired()
    {
        Destroy(this.transform.GetChild(0).GetChild(0).gameObject);

        GameObject repairedSwordInst = Instantiate(repairedAxe, transform.position, transform.rotation);

        repairedSwordInst.transform.parent = this.transform.GetChild(0);

        repairedSwordInst.transform.localScale = new Vector3(1, 1, 1);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Weapon
{

    protected string nextRecipe;
    public virtual string NextRecipe { get => nextRecipe; }

    [SerializeField]
    private ITEMTYPE type;

    public ITEMTYPE Type { get => type; }

    [SerializeField]
    protected bool isBroken = true;
    [SerializeField]
    protected bool isHeated = false;
    [SerializeField]
    protected bool isForged = false;
    [SerializeField]
    protected bool isChilled = false;
    [SerializeField]
    protected bool isReady = false;
    [SerializeField]
    protected bool isWoodEnchanted = false;

    [SerializeField]
    protected int requiredOres = 1;

    [SerializeField]
    private int requiredWoods = 1;

    protected int timeToHeat = 7;


    public int RequiredOres { get => requiredOres; }
    public int TimeToHeat { get => timeToHeat; }


    public bool IsBroken { get => isBroken; }
    public bool IsHeated { get => isHeated; }
    public bool IsForged { get => isForged; }
    public bool IsChilled { get => isChilled; }
    public bool IsReady { get => isReady; }
    public int RequiredWoods { get => requiredWoods; }
    public bool IsWoodEnchanted { get => isWoodEnchanted; }

    [SerializeField]
    private List<GameObject> brokenItems = new List<GameObject>();

    [SerializeField]
    private GameObject repairedItem;

    private void Start()
    {
        if(isBroken)
        {
            GameObject brokenItem = Instantiate(brokenItems[Random.Range(0, brokenItems.Count)], transform.position, transform.rotation);

            brokenItem.transform.parent = this.transform.GetChild(0);

            brokenItem.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public virtual string GetNextRecipe()
    {
        return type.ToString();
    }
    public void SetModelToRepaired()
    {
        Destroy(this.transform.GetChild(0).GetChild(0).gameObject);

        GameObject repairedSwordInst = Instantiate(repairedItem, transform.position, transform.rotation);

        repairedSwordInst.transform.parent = this.transform.GetChild(0);

        repairedSwordInst.transform.localScale = new Vector3(1, 1, 1);
    }

    public virtual void Preheat()
    {
        isBroken = false;
        isHeated = true;
        //fireParticles.SetActive(true);
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;

        damage += 10;
    }

    public virtual void Forge()
    {
        //fireParticles.SetActive(false);
        isHeated = false;
        isForged = true;
        GetComponentInChildren<MeshRenderer>().material.color = new Color(0.4f, 0, 0);

        damage += 10;
    }

    public virtual void Chill()
    {
        isForged = false;
        isChilled = true;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        //isReady = true;

        damage += 10;
    }

    public virtual void Enchant()
    {
        isChilled = false;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        damage += 10;
    }

}

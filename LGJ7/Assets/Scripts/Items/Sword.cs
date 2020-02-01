using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
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
    private bool isReady = false;
    [SerializeField]
    private int requiredOres = 2;
    private int timeToHeat = 7;

    [SerializeField]
    private List<GameObject> brokenSwords = new List<GameObject>();

    [SerializeField]
    private GameObject repairedSword;

    public bool IsBroken { get => isBroken; }
    public bool IsHeated { get => isHeated; }
    public bool IsForged { get => isForged; }
    public bool IsChilled { get => isChilled; }
    public bool IsReady { get => isReady; }
    public int RequiredOres { get => requiredOres; }
    public int TimeToHeat { get => timeToHeat; }

    [SerializeField]
    private GameObject fireParticles;

    private void Start()
    {
        GameObject brokenSword = Instantiate(brokenSwords[Random.Range(0, brokenSwords.Count)], transform.position, transform.rotation);

        brokenSword.transform.parent = this.transform.GetChild(0);

        brokenSword.transform.localScale = new Vector3(1,1,1);
    }

    public void SetModelToRepaired()
    {
        Destroy(this.transform.GetChild(0).GetChild(0).gameObject);

        GameObject repairedSwordInst = Instantiate(repairedSword, transform.position, transform.rotation);

        repairedSwordInst.transform.parent = this.transform.GetChild(0);

        repairedSwordInst.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Preheat()
    {
        isBroken = false;
        isHeated = true;
        fireParticles.SetActive(true);
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    public void Forge()
    {
        fireParticles.SetActive(false);
        isHeated = false;
        isForged = true;
        GetComponentInChildren<MeshRenderer>().material.color = new Color(0.4f, 0, 0);
    }

    public void Chill()
    {
        isForged = false;
        isChilled = true;

        GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;

        isReady = true;
    }
}

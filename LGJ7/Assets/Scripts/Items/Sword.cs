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
    private int timeToHeat = 5;

    public bool IsBroken { get => isBroken; }
    public bool IsHeated { get => isHeated; }
    public bool IsForged { get => isForged; }
    public bool IsChilled { get => isChilled; }
    public bool IsReady { get => isReady; }
    public int RequiredOres { get => requiredOres; }
    public int TimeToHeat { get => timeToHeat; }


    public void Preheat()
    {
        isBroken = false;
        isHeated = true;
    }

    public void Forge()
    {
        isHeated = false;
        isForged = true;
    }

    public void Chill()
    {
        isForged = false;
        isChilled = true;

        isReady = true;
    }
}

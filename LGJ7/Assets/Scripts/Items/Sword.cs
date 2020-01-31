﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    private bool isHeated = false;
    private bool isForged = false;
    private bool isChilled = false;
    private bool isReady = false;

    public bool IsHeated { get => isHeated; }
    public bool IsForged { get => isForged; }
    public bool IsChilled { get => isChilled; }
    public bool IsReady { get => isReady; }

    public void Preheat()
    {
        isHeated = true;
    }

    public void Forge()
    {
        isForged = true;
    }

    public void Chill()
    {
        isChilled = true;

        isReady = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : InteractableObject
{
    [SerializeField]
    private int heatLevel = 0;

    [SerializeField]
    private int minimumHeat = 10;

    [SerializeField]
    private int maxHeatLevel = 20;

    [SerializeField]
    private Slider heatSlider;

    [SerializeField]
    private Image sliderBackground;

    private void Start()
    {
        InvokeRepeating("DecreaseHeatLevel", 0, 1);
        GetComponentInChildren<Slider>().value = 0;
    }


    private float time = 0;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>().IsBroken)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();
            itemSlot.Item.GetComponentInChildren<Slider>().value = 0;

        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>() && itemSlot.Item.GetComponent<Sword>().IsHeated)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }

    }

    void Update()
    {
        if(itemSlot.Item != null && !itemSlot.Item.GetComponent<Sword>().IsHeated )
        {
            Heating();
        }
    }

    private void Heating()
    {     
        if(itemSlot.Item.GetComponent<Sword>().TimeToHeat > time && heatLevel >= minimumHeat)
        {
            time += Time.deltaTime;
            
            itemSlot.Item.GetComponentInChildren<Slider>().value = time / itemSlot.Item.GetComponent<Sword>().TimeToHeat;
        }
        else if (itemSlot.Item.GetComponent<Sword>().TimeToHeat <= time)
        {
            itemSlot.Item.GetComponent<Sword>().Preheat();
            itemSlot.Item.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }

    public void PreheatFurnace()
    {
        heatLevel += 5;
        heatSlider.value = heatLevel / (float)maxHeatLevel;
        if (heatLevel >= minimumHeat)
            sliderBackground.color = Color.red;
        if (heatLevel > maxHeatLevel)
            heatLevel = maxHeatLevel;
    }

    public void DecreaseHeatLevel()
    {
        heatLevel--;
        heatSlider.value = heatLevel / (float)maxHeatLevel;
        if (heatLevel < minimumHeat)
            sliderBackground.color = Color.blue;
        if (heatLevel < 0)
            heatLevel = 0;
    }
    
}

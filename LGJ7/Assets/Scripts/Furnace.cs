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

        audioSource.clip = audioClips[0];
    }


    private float time = 0;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Item>().IsBroken)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();
            fillableCircle.transform.parent.gameObject.SetActive(true);
            fillableCircle.fillAmount = 0;
            //itemSlot.Item.GetComponentInChildren<ItemClock>().transform.GetChild(0).gameObject.SetActive(true);
            //itemSlot.Item.GetComponentInChildren<ItemClock>().fillImage.fillAmount = 0;

        }
        else if (!playersItemSlot.Item && itemSlot.Item && itemSlot.Item.GetComponent<Item>() && itemSlot.Item.GetComponent<Item>().IsHeated)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);
            fillableCircle.transform.parent.gameObject.SetActive(false);
            // itemSlot.Item.GetComponentInChildren<ItemClock>().transform.GetChild(0).gameObject.SetActive(false);
            itemSlot.RemoveItemFromSlot();
        }

    }

    void Update()
    {
        if(itemSlot.Item != null && !itemSlot.Item.GetComponent<Item>().IsHeated )
        {
            Heating();
        }
    }

    private void Heating()
    {     
        if(itemSlot.Item.GetComponent<Item>().TimeToHeat > time && heatLevel >= minimumHeat)
        {
            time += Time.deltaTime;

            fillableCircle.fillAmount = time / itemSlot.Item.GetComponent<Item>().TimeToHeat;
            
        }
        else if (itemSlot.Item.GetComponent<Item>().TimeToHeat <= time)
        {
            itemSlot.Item.GetComponent<Item>().Preheat();
            time = 0;
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

        if (!audioSource.isPlaying)
            audioSource.Play();

        //GetComponentInChildren<ParticleSystem>().gameObject.transform.localScale = new Vector3(2, 2, 2);
    }

    public void DecreaseHeatLevel()
    {
        heatLevel--;
        heatSlider.value = heatLevel / (float)maxHeatLevel;
        if (heatLevel < minimumHeat)
            sliderBackground.color = Color.blue;
        if (heatLevel < 0)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();

            //GetComponentInChildren<ParticleSystem>().gameObject.transform.localScale = new Vector3(1, 1, 1);

            heatLevel = 0;
        }
    }
    
}

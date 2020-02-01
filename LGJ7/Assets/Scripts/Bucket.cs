using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : InteractableObject
{
    private float time = 0;
    private float timeOfChilling = 5;
    private float waterLevel;
    private float maxWaterLevel = 19;

    [SerializeField]
    private Image sliderBackground;

    [SerializeField]
    private Slider waterLevelSlider;

    [SerializeField]
    private ParticleSystem particles;


    private void Start()
    {
        InvokeRepeating("DecreaseWaterLevel", 0, 1);
        waterLevel = maxWaterLevel;
        waterLevelSlider.value = waterLevel / (float)maxWaterLevel;

    }
    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Item>() && playersItemSlot.Item.GetComponent<Item>().IsForged)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);
            fillableCircle.transform.parent.gameObject.SetActive(true);
            fillableCircle.fillAmount = 0;
            playersItemSlot.RemoveItemFromSlot();

            itemSlot.Item.transform.GetChild(0).transform.Rotate(0, 180, 0);

            particles.Play();
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Cup>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            AddWater();
        }
        else if (!playersItemSlot.Item && itemSlot.Item && itemSlot.Item.GetComponent<Item>() && itemSlot.Item.GetComponent<Item>().IsChilled)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);
            fillableCircle.transform.parent.gameObject.SetActive(false);
            itemSlot.RemoveItemFromSlot();

            particles.Stop();
        }

    }
    void Update()
    {
        if (itemSlot.Item != null && !itemSlot.Item.GetComponent<Item>().IsChilled)
        {
            Chilling();
        }
    }
    private void Chilling()
    {

        if (timeOfChilling > time && waterLevel > 0)
        {
            time += Time.deltaTime;
            fillableCircle.fillAmount = time / timeOfChilling;
        }
        else if(timeOfChilling <= time)
        {
            itemSlot.Item.GetComponent<Item>().Chill();
            itemSlot.Item.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            time = 0;
        }
    }

    public void AddWater()
    {
        waterLevel = maxWaterLevel;
        waterLevelSlider.value = waterLevel / (float)maxWaterLevel;
    }

    public void DecreaseWaterLevel()
    {
        if (itemSlot.Item != null && !itemSlot.Item.GetComponent<Item>().IsChilled)
        {
            waterLevel--;
            waterLevelSlider.value = waterLevel / (float)maxWaterLevel;

            if (waterLevel < 0)
                waterLevel = 0;
        }
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : InteractableObject
{
    [SerializeField]
    private int requiredOres = 0;

    [SerializeField]
    private int requiredHits = 5;

    private int hits = 0;

    private Slider itemSlider;

    [SerializeField]
    private ParticleSystem tinyExplosion;

    public override void Use(ItemSlot playersItemSlot)
    {
        if(miniGameActive)
        {
            CheckMiniGameStatus();
        }
        else if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Item>() 
            && playersItemSlot.Item.GetComponent<Item>().IsHeated)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            itemSlot.Item.transform.localScale = new Vector3(1, 1, 1);
          
            playersItemSlot.RemoveItemFromSlot();

            requiredOres = itemSlot.Item.GetComponent<Item>().RequiredOres;

            hits = requiredHits;

           // itemSlider = itemSlot.Item.GetComponentInChildren<Slider>();

            //itemSlider.value = 0;
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Ore>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            requiredOres--;

            if (requiredOres == 0)
                StartMiniGame();
        }
        else if (!playersItemSlot.Item && itemSlot.Item && itemSlot.Item.GetComponent<Item>() && itemSlot.Item.GetComponent<Item>().IsForged)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);
            fillableCircle.transform.parent.gameObject.SetActive(false);
           // itemSlot.Item.GetComponentInChildren<ItemClock>().transform.GetChild(0).gameObject.SetActive(false);
            itemSlot.RemoveItemFromSlot();
        }
    }

    private void Forge()
    {
        itemSlot.Item.GetComponent<Item>().SetModelToRepaired();

        itemSlot.Item.GetComponent<Item>().Forge();
    }

    [SerializeField]
    private Slider miniGameSlider;

    [SerializeField]
    private float correctAreaRange = 60.0f;

    [SerializeField]
    private GameObject correctArea;

    [SerializeField]
    private AnvilMiniGamePointer pointer;

    private bool miniGameActive = false;

    private bool markerGoingRight = true;

    private void StartMiniGame()
    {
        miniGameSlider.gameObject.SetActive(true);
        miniGameActive = true;
        fillableCircle.transform.parent.gameObject.SetActive(true);
        fillableCircle.fillAmount = 0;

        SetRandomCorrectArea();
    }

    private void SetRandomCorrectArea()
    {
        float x = Random.Range((-1) * correctAreaRange, correctAreaRange);

        correctArea.GetComponent<RectTransform>().transform.localPosition
            = new Vector3(x, correctArea.GetComponent<RectTransform>().transform.localPosition.y, correctArea.GetComponent<RectTransform>().transform.localPosition.z);

        correctArea.GetComponent<RectTransform>().transform.right = new Vector2(x, 0);

        correctArea.GetComponent<RectTransform>().transform.localRotation = Quaternion.identity;
    }

    private void CheckMiniGameStatus()
    {
        if (pointer.isInCorrectArea)
        {
            hits--;        

            if (hits <= 0)
            {
                miniGameSlider.gameObject.SetActive(false);
                miniGameActive = false;
                Forge();
            }

            tinyExplosion.Play();
            audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
            audioSource.Play();
        }
        else
            hits = requiredHits;

        SetRandomCorrectArea();
        fillableCircle.fillAmount  = (5 - hits) / (float)requiredHits;
        //itemSlider.value = (5 - hits) / (float)requiredHits;
    }

    private void Update()
    {
        if(miniGameActive)
        {
            if (markerGoingRight)
            {
                miniGameSlider.value += Time.deltaTime;

                if (miniGameSlider.value >= 1)
                    markerGoingRight = false;
            }
            else
            {
                miniGameSlider.value -= Time.deltaTime;

                if (miniGameSlider.value <= 0)
                    markerGoingRight = true;
            }
        }
    }
}

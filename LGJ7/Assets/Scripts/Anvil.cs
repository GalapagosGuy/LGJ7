using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : InteractableObject
{
    [SerializeField]
    private int requiredOres = 0;

    public override void Use(ItemSlot playersItemSlot)
    {
        if(miniGameActive)
        {
            CheckMiniGameStatus();
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Sword>() 
            && playersItemSlot.Item.GetComponent<Sword>().IsHeated)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            playersItemSlot.RemoveItemFromSlot();

            requiredOres = itemSlot.Item.GetComponent<Sword>().RequiredOres;
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Ore>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            requiredOres--;

            if (requiredOres == 0)
                StartMiniGame();
        }
        else if (!playersItemSlot.Item && itemSlot.Item.GetComponent<Sword>().IsForged)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);

            itemSlot.RemoveItemFromSlot();
        }
    }

    private void Forge()
    {
        itemSlot.Item.GetComponent<Sword>().Forge();
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
            SetRandomCorrectArea();
        else
            Debug.Log("XD");
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

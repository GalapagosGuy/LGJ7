using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantTable : InteractableObject
{
    [SerializeField]
    private int requiredWoods = 0;

    [SerializeField]
    private ParticleSystem tinyExplosion;

    public override void Use(ItemSlot playersItemSlot)
    {
        if (playersItemSlot.Item && !itemSlot.Item && playersItemSlot.Item.GetComponent<Item>()
            && playersItemSlot.Item.GetComponent<Item>().IsChilled)
        {
            itemSlot.AddItemToSlot(playersItemSlot.Item);

            itemSlot.Item.transform.localScale = new Vector3(1, 1, 1);

            playersItemSlot.RemoveItemFromSlot();

            requiredWoods = itemSlot.Item.GetComponent<Item>().RequiredWoods;
        }
        else if (playersItemSlot.Item && playersItemSlot.Item.GetComponent<Wood>())
        {
            Destroy(playersItemSlot.Item);
            playersItemSlot.RemoveItemFromSlot();

            requiredWoods--;

            if (requiredWoods == 0)
                StartMiniGame(playersItemSlot);
        }
        else if (!playersItemSlot.Item && itemSlot.Item && itemSlot.Item.GetComponent<Item>() && itemSlot.Item.GetComponent<Item>().IsWoodEnchanted)
        {
            playersItemSlot.AddItemToSlot(itemSlot.Item);
            itemSlot.Item.GetComponentInChildren<ItemClock>().transform.GetChild(0).gameObject.SetActive(false);
            itemSlot.RemoveItemFromSlot();
        }
    }

    private void Enchant()
    {
        itemSlot.Item.GetComponent<Item>().Enchant();
    }

    [SerializeField]
    private List<Image> imagesWithText = new List<Image>();

    private List<KeyCode> password = new List<KeyCode>();
    private List<string> passwordString = new List<string>();

    private bool miniGameWorking = false;

    private int activeSlot = 0;

    [SerializeField]
    private GameObject minigameCanvas;

    private ItemSlot playersItemSlotCopy;

    int activePlayer = 0;

    private void StartMiniGame(ItemSlot playersItemSlot)
    {
        password.Clear();
        passwordString.Clear();

        minigameCanvas.SetActive(true);

        playersItemSlotCopy = playersItemSlot;

        if (playersItemSlot.transform.root.name == "Player")
        {
            activePlayer = 0;

            for (int i = 0; i < 4; i++)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        password.Add(KeyCode.J);
                        break;
                    case 1:
                        password.Add(KeyCode.K);
                        break;
                    case 2:
                        password.Add(KeyCode.L);
                        break;
                }
            }
        }
        else
        {
            activePlayer = 1;

            for (int i = 0; i < 4; i++)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        passwordString.Add("Player2ActionL1");
                        break;
                    case 1:
                        passwordString.Add("Player2ActionR1");
                        break;
                    case 2:
                        passwordString.Add("ActionPlayer2");
                        break;
                }
            }
        }


        if(password.Count != 0)
        {
            for (int i = 0; i < 4; i++)
            {
                imagesWithText[i].GetComponentInChildren<Text>().text = password[i].ToString();
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                switch (passwordString[i])
                {
                    case "Player2ActionL1":
                        imagesWithText[i].GetComponentInChildren<Text>().text = "L1";
                        break;
                    case "Player2ActionR1":
                        imagesWithText[i].GetComponentInChildren<Text>().text = "R1";
                        break;
                    case "ActionPlayer2":
                        imagesWithText[i].GetComponentInChildren<Text>().text = "X";
                        break;
                }
            }
        }


        imagesWithText[0].GetComponent<Image>().color = Color.yellow;

        activeSlot = 0;
        miniGameWorking = true;
    }

    private void Update()
    {
        if(miniGameWorking)
        {
            Debug.Log("MiniGame working");

            if(activePlayer == 0 && Input.anyKeyDown && password.Count != 0 && playersItemSlotCopy.transform.root.gameObject.GetComponent<PlayerController>().InteractableObject == this)
            {
                if (Input.GetKeyDown(password[activeSlot]))
                {
                    Debug.Log("CorrectKeyPressed");

                    activeSlot++;


                    if (activeSlot >= 4)
                    {
                        Enchant();
                        minigameCanvas.SetActive(false);
                        miniGameWorking = false;

                        imagesWithText[activeSlot - 1].GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        imagesWithText[activeSlot - 1].GetComponent<Image>().color = Color.white;
                        imagesWithText[activeSlot].GetComponent<Image>().color = Color.yellow;
                    }
                }
                else
                {
                    Debug.Log("Password Incorrect - reset!");

                    imagesWithText[activeSlot].GetComponent<Image>().color = Color.white;

                    StartMiniGame(playersItemSlotCopy);
                }
            }

            if(activePlayer == 1 && playersItemSlotCopy.transform.root.gameObject.GetComponent<PlayerController>().InteractableObject == this)
            {
                if((Input.GetButtonDown("Player2ActionL1") && passwordString[activeSlot] == "Player2ActionL1")
                    || (Input.GetButtonDown("Player2ActionR1") && passwordString[activeSlot] == "Player2ActionR1")
                    || (Input.GetButtonDown("ActionPlayer2") && passwordString[activeSlot] == "ActionPlayer2"))
                {
                    Debug.Log("CorrectKeyPressed");

                    activeSlot++;


                    if (activeSlot >= 4)
                    {
                        Enchant();
                        minigameCanvas.SetActive(false);
                        miniGameWorking = false;

                        imagesWithText[activeSlot - 1].GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        imagesWithText[activeSlot - 1].GetComponent<Image>().color = Color.white;
                        imagesWithText[activeSlot].GetComponent<Image>().color = Color.yellow;
                    }
                }
                else if (Input.GetButtonDown("Player2ActionL1") || Input.GetButtonDown("Player2ActionR1") || Input.GetButtonDown("ActionPlayer2"))
                {
                    Debug.Log("Password Incorrect - reset!");

                    imagesWithText[activeSlot].GetComponent<Image>().color = Color.white;

                    StartMiniGame(playersItemSlotCopy);
                }
            }

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text geldText;

    [SerializeField]
    private Text geldEnd;

    [SerializeField]
    private GameObject playmenu;
    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject player1Hud;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private GameObject player2Hud;

    [SerializeField]
    private GoblinSpawner spawner;
    private int geld = 0;

    public int Geld { get => geld; set => geld = value; }

    public void AddGeld(int geldAdded)
    {
        geld += geldAdded;
    }
    void Update()
    {
        geldText.text = "Gold: " + geld;
        geldEnd.text = "Your forged earned " + geld +  " gold!";
        if (player1.activeSelf == false && player2.activeSelf == true)
        {
            if(spawner.AreAllGoblinsDefeated())
            {
                RessurectPlayer(player1, player2Hud);
            }
        }
        if (player1.activeSelf == true && player2.activeSelf == false)
        {
            if (spawner.AreAllGoblinsDefeated())
            {
                RessurectPlayer(player2, player2Hud);
            }
        }
        if (player1.activeSelf == false && player2.activeSelf == false && playmenu.activeSelf == true)
        {

            RessurectPlayer(player1, player1Hud);
            RessurectPlayer(player2, player2Hud);

        }
    }

    private void RessurectPlayer(GameObject player, GameObject playerHud)
    {
        geld -= 100;
        if (geld < 0)
            geld = 0;
        player.SetActive(true);
        playerHud.SetActive(true);
        player.GetComponent<PlayerController>().AddHealth(player.GetComponent<PlayerController>().GetMaxHealth);
    }
}

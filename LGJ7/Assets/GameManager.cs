using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text geldText;
    private int geld = 0;

    public int Geld { get => geld; set => geld = value; }

    public void AddGeld(int geldAdded)
    {
        geld += geldAdded;
    }
    void Update()
    {
        geldText.text = "Geld: " + geld;
    }
}

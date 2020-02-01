using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClock : MonoBehaviour
{
    
    [SerializeField]
    public Image fillImage;

    private void Start()
    {
        fillImage.fillAmount = 0f;
    }

   
}

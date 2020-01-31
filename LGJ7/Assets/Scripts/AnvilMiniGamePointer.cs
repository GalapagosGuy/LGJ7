using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMiniGamePointer : MonoBehaviour
{
    public bool isInCorrectArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AnvilMiniGameCorrectArea")
            isInCorrectArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AnvilMiniGameCorrectArea")
            isInCorrectArea = false;
    }
}

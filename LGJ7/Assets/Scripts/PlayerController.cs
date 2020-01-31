using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InteractableObject interactableObject;

    public void ActivateInteractableObject()
    {
        interactableObject.Use();
    }
}

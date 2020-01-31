using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            playerController.ActivateInteractableObject();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private string playerAction;
    [SerializeField]
    private string playerAttack;

    private void Update()
    {
        if(Input.GetButtonDown(playerAction))
        {
            playerController.ActivateInteractableObject();
        }

        if (Input.GetButtonDown(playerAttack))
        {
            playerController.Attack();
        }

    }
}

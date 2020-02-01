using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimLocks : MonoBehaviour
{
    public PlayerKeyboardController controller;

    public void LockAnimActions()
    {
        controller?.LockAnimActions();
    }


    public void UnlockAnimActions()
    {
        controller?.UnlockAnimActions();
    }
}

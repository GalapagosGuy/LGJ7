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

    [SerializeField]
    private AudioSource footSound;

    [SerializeField]
    private List<AudioClip> footSteps = new List<AudioClip>();

    public void PlayStepSound()
    {
        //if (!footSound.isPlaying)
        //{
            footSound.clip = footSteps[Random.Range(0, footSteps.Count)];
            footSound.Play();

        //}
    }
}

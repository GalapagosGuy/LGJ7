using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemSlot), typeof(AudioSource))]
public abstract class InteractableObject : MonoBehaviour
{
    protected ItemSlot itemSlot;
    [SerializeField]
    protected Image fillableCircle;

    [SerializeField]
    protected List<AudioClip> audioClips = new List<AudioClip>();

    protected AudioSource audioSource;

    protected virtual void Awake()
    {

        //fillableCircle.transform.GetComponentInParent<GameObject>().SetActive(true);
        itemSlot = GetComponent<ItemSlot>();

        audioSource = GetComponent<AudioSource>();
    }

    public abstract void Use(ItemSlot playersItemSlot);
    
}

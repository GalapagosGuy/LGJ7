using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    public int GetMaxHealth { get => maxHealth; }
   
    [SerializeField]
    protected GameObject puffEffect;

    [SerializeField]
    private Slider hpBarSlider;

    protected int health;

    protected AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> hitSound = new List<AudioClip>();

    [SerializeField]
    protected AudioClip deathSound;

    protected virtual void Awake()
    {
        health = maxHealth;
        hpBarSlider.value = health / (float)maxHealth;

        audioSource = GetComponent<AudioSource>();
    }

    public virtual void GetHit(int damage)
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = hitSound[Random.Range(0, hitSound.Count)];
            audioSource.Play();
        }

        health -= damage;
        hpBarSlider.value = health / (float)maxHealth;
        CheckDeathCondition();
    }

    public virtual void AddHealth(int healed)
    {
        health += healed;
        if (health > maxHealth)
            health = maxHealth;
        hpBarSlider.value = health / (float)maxHealth;
        
    }

    public virtual void CheckDeathCondition()
    {
        if (health <= 0)
        {
            audioSource.clip = deathSound;
            audioSource.Play();


            Destroy(Instantiate(puffEffect, transform.position, transform.rotation), 2f);
            Destroy(this.transform.root.gameObject);
        }
    }
}

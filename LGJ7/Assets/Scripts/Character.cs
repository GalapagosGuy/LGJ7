using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private GameObject puffEffect;

    [SerializeField]
    private Slider hpBarSlider;

    protected int health;

    protected virtual void Awake()
    {
        health = maxHealth;
        hpBarSlider.value = health / (float)maxHealth;
    }

    public virtual void GetHit(int damage)
    {
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
            Destroy(Instantiate(puffEffect, transform.position, transform.rotation), 2f);
            Destroy(this.transform.root.gameObject);
        }
    }
}

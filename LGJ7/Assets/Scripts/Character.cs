using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private GameObject puffEffect;

    protected int health;

    protected virtual void Awake()
    {
        health = maxHealth;
    }

    public virtual void GetHit(int damage)
    {
        health -= damage;

        CheckDeathCondition();
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

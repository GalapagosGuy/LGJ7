using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinController : Character
{
    private NavMeshAgent agent;

    private Animator animator;

    private bool canDoAction = true;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void GoTo(Vector3 target)
    {
        if (canDoAction)
        {
            agent.isStopped = false;
            agent.SetDestination(target);
            animator.SetBool("isRunning", true);
        }
        else
            agent.isStopped = true;
    }

    public void Attack()
    {
        if (canDoAction)
        {
            animator.SetTrigger("attackTrigger");
        }
    }

    public void LockActions()
    {
        canDoAction = false;
    }

    public void UnlockActions()
    {
        canDoAction = true;
    }

    public Collider weaponCollider;
    public Weapon weapon;

    public void AllowToDealDamage()
    {
        weapon.Reset();
        weaponCollider.enabled = true;
    }

    public void LockDealingDamage()
    {
        weaponCollider.enabled = false;
    }

    public override void CheckDeathCondition()
    {
        if (health <= 0)
            GoblinSpawner.instance.GoblinDefeated();

        base.CheckDeathCondition();
    }
}

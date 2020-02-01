using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinController : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    public GameObject player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(player)
            GoTo(player.transform.position);
    }

    public void GoTo(Vector3 target)
    {
        agent.SetDestination(target);
    }
}

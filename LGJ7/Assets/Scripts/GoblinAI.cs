using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GoblinController))]
public class GoblinAI : MonoBehaviour
{
    [SerializeField]
    public GameObject target;

    private GoblinController controller;

    private void Awake()
    {
        controller = GetComponent<GoblinController>();
    }


    private void Update()
    {
        if (target)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) > 2.0f)
                controller.GoTo(target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            controller.Attack();
    }
}

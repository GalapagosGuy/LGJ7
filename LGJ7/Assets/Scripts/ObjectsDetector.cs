using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDetector : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<InteractableObject>())
        {
            Debug.Log("I SEE HIM!");
            playerController?.SetInteractableObject(other.GetComponent<InteractableObject>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractableObject>())
        {
            Debug.Log("WHERE IS IT?!?!!?");
            playerController?.SetInteractableObject(null);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InteractableObject>())
        {
            playerController?.SetInteractableObject(other.GetComponent<InteractableObject>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractableObject>())
        {
            Debug.Log("WHERE IS IT?!?!!?");
            playerController?.SetInteractableObject(null);
        }
    }
}

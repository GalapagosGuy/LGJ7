using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorsScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && GetComponent<Animator>().GetBool("doorsOpen") == false)
        {
            GetComponent<Animator>().SetTrigger("openTheDoor");
        }
    }

    public void CloseTheDoor()
    {
        if(GetComponent<Animator>().GetBool("doorsOpen") == true)
        { 
            GetComponent<Animator>().SetTrigger("closeTheDoor");
        }
    }

    public void SetDoorsOpen()
    {
        GetComponent<Animator>().SetBool("doorsOpen", true);
    }

    public void SetDoorsClosed()
    {
        GetComponent<Animator>().SetBool("doorsOpen", false);
    }
}

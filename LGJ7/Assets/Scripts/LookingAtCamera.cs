using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    
    
    void Update()
    {
        transform.LookAt(transform.position + mycamera.transform.rotation * Vector3.back, mycamera.transform.rotation * Vector3.up);
    }
}

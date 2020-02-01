using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
    [SerializeField] Camera mycamera;
    private Quaternion iniRot;
    void Start()
    {
        iniRot = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = iniRot;
    }
}

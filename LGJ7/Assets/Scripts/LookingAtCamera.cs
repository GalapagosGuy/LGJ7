﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
   
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        // transform.LookAt(transform.position + StaticCamera.Instance.transform.rotation * Vector3.back, StaticCamera.Instance.transform.rotation * Vector3.up);
    }
}

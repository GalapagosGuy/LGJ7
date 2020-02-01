using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingRotate : MonoBehaviour
{
    Quaternion original;
    void Start()
    {
        original = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = original;
    }
}

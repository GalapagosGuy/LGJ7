using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float distance = 10;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, this.transform.position.y, target.position.z - distance);
    }
}

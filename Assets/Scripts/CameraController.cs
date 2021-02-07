using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float distance;
    [SerializeField]
    float cameraSmooth;
    Vector3 velocity;

    void LateUpdate()
    {
        Vector3 newPos = target.transform.position + transform.forward * -distance;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, cameraSmooth);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
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

    // bool _inheritRotation = false at the end
    internal void ChangeTarget(Transform _target, float _distance, 
        float _smooth)
    {
        target = _target;
        distance = _distance;
        cameraSmooth = _smooth;
    }
    public void InheritRotation(Transform rotationPivot, bool localRotation)
    {
        if(localRotation == true)
        {
            //transform.rotation = rotationPivot.localRotation;
        }
        else
        {
            //transform.rotation = rotationPivot.rotation;
        }
    }

    public void Warp(Vector3 worldPosition, bool prebake = false)
    {
        if(prebake == false)
        {
            transform.position = worldPosition;
        }
        else
        {
            Vector3 newPos = target.transform.position + transform.forward * -distance;

            transform.position = newPos;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Transform boxPivot;
    [SerializeField]
    Vector3 boxHalfSize = Vector3.one;

    public void CheckInteract()
    {
        Collider[] colliders = Physics.OverlapBox(boxPivot.position, boxHalfSize);
        foreach(Collider c in colliders)
        {
            Interactable interactable = c.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.Interact(gameObject);
                break;
            }
        }
    }
}

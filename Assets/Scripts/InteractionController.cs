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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckInteract();
        }
    }

    void CheckInteract()
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

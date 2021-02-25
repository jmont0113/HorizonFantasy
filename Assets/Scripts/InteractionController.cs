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

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //**TODO** remove this, and seperate into a different controller
            if (DialogueManager.instance.canvas.activeInHierarchy == true)
            {
                DialogueManager.instance.Next();
            }
            else
            {
                CheckInteract();
            }
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

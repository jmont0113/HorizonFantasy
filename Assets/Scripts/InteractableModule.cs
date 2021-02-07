using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
abstract public class InteractableModule : MonoBehaviour
{

    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        if(interactable == null)
        {
            Debug.LogError("No interactable script detected!");
            return;
        }
        interactable.onInteract += Interact;
    }

    public abstract void Interact(GameObject actor);
}

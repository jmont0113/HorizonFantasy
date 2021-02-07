using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public Action <GameObject> onInteract;

    public void Interact(GameObject actor)
    {
        onInteract?.Invoke(actor);
        if(onInteract == null)
        {
            Debug.LogWarning("No onInteract methods were linked to this Interactable");
        }
    }
}

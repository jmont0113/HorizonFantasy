using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDebugMessage : InteractableModule
{
    [SerializeField]
    string message;

    public override void Interact(GameObject actor)
    {
        Debug.Log(message);
    }
}

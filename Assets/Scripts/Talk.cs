using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : InteractableModule
{
    [SerializeField] Dialogue dialogue;
    public override void Interact(GameObject actor)
    {
        if(dialogue != null)
        {
            GameManager.instance.dialogueManager.StartDialogue(dialogue);
        }
    }
}

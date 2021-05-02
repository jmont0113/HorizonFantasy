using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : InteractableDialogue
{
    public DialogueBase DB;

    public override void Interact()
    {
        DialoguesManager.instance.EnqueueDialogue(DB);
    }
}

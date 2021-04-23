using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;

    public void TriggerDialogue()
    {
        DialoguesManager.instance.EnqueueDialogue(dialogue);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TriggerDialogue();
        }
    }
}

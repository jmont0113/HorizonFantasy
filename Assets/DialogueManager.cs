using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text nameText, dialogueText;
    public GameObject canvas;
    Queue<string> text;
    Queue<Actor> actor;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        text = new Queue<string>();
        actor = new Queue<Actor>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.SetActive(true);

        text.Clear();
        actor.Clear();

        for (int i = 0; i < dialogue.text.Length; i++)
        {
            text.Enqueue(dialogue.text[i]);
            actor.Enqueue(dialogue.actor[i]);
        }
        Next();
    }

    public void Next()
    {
        if(text.Count == 0)
        {
            Debug.Log("End of the dialogue");
            canvas.SetActive(false);
        }
        else
        {
            Actor a = actor.Dequeue();
            if(a == null)
            {
                nameText.text = "Narrator";
            }
            else
            {
                nameText.text = a.Name;
            }

            dialogueText.text = text.Dequeue();
        }
    }
}

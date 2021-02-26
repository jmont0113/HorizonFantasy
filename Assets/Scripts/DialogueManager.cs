using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText, dialogueText;
    public GameObject canvas;
    Queue<string> text;
    Queue<Actor> actor;

    public AudioSource talkingSound;

    private void Awake()
    {
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
            talkingSound.Play();
        }

        GameManager.instance.SetControlScheme(ControlScheme.Dialogue);
        Next();
    }

    public void Next()
    {
        if(text.Count == 0)
        {
            GameManager.instance.SetControlScheme(ControlScheme.Exploration);
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
            talkingSound.Play();
        }
    }
}

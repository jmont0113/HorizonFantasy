using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCharacterValue : MonoBehaviour
{
    public Value trackValue;
    public Character character;
    Text text;

    void UpdateText()
    {
        string str = character.statsContainer.GetText(trackValue);
        if(text == null)
        {
            text = GetComponent<Text>();
        }
        text.text = str;
    }

    public void Set(Value _trackValue, Character _character)
    {
        character = _character;
        trackValue = _trackValue;
        if (text == null)
        {
            text = GetComponent<Text>();
        }
        text.text = character.statsContainer.GetText(trackValue);
        character.statsContainer.Subscribe(UpdateText, trackValue);
    }
}

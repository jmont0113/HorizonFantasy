﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCharacterValue : MonoBehaviour
{
    public Value trackValue;
    public Character character;

    void UpdateText()
    {
        string str = character.statsContainer.GetText(trackValue);
        GetComponent<Text>().text = str;
    }

    /*// Start is called before the first frame update
    void Start()
    {
        character.statsContainer.Subscribe(UpdateText, trackValue);
        UpdateText();
    }*/

    public void Set(Value _trackValue, Character _character)
    {
        GetComponent<Text>().text = _trackValue.Name;
    }
}

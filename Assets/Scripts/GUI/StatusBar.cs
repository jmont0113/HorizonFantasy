using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    Value trackValue;
    CombatCharacter character;
    Image bar;

    ValueFloatReference currentFloat;
    ValueFloatReference maxFloat;

    ValueIntReference currentInt;
    ValueIntReference maxInt;
    float filledAmount;

    [SerializeField] Text text;

    Action calculate;

    public void UpdateBar()
    {
        calculate?.Invoke();

        bar.fillAmount = filledAmount;
    }

    void CalculateInt()
    {
        filledAmount = ((float)currentInt.value / maxInt.value);
        bar.fillAmount = filledAmount;
        text.text = currentInt.value.ToString();
    }

    void CalculateFloat()
    {
        filledAmount = currentFloat.value / maxFloat.value;
        bar.fillAmount = filledAmount;
        text.text = currentFloat.value.ToString();
    }

    public void Set(Value _trackValue, CombatCharacter _character)
    {
        trackValue = _trackValue;
        character = _character;
        bar = transform.GetChild(0).GetComponent<Image>();
        character.actionTimer.currentAT.onChange += UpdateBar;
    }

    public void Set(ValueReference current, ValueReference max)
    {
        if(current is ValueIntReference)
        {
            currentInt = (ValueIntReference)current;
            maxInt = (ValueIntReference)max;
            currentInt.onChange += UpdateBar;
            maxInt.onChange += UpdateBar;
            calculate = CalculateInt;
        }
        else
        {
            currentFloat = (ValueFloatReference)current;
            maxFloat = (ValueFloatReference)max;
            currentFloat.onChange += UpdateBar;
            maxFloat.onChange += UpdateBar;
            calculate = CalculateFloat;
        }

        bar = transform.GetChild(0).GetComponent<Image>();
        UpdateBar();
    }
}

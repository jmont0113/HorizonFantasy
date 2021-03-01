using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    Value trackValue;
    CombatCharacter character;
    Image bar;

    public void UpdateBar()
    {
        float filledAmount = character.GetFillAmount(trackValue);

        bar.fillAmount = filledAmount;
    }

    public void Set(Value _trackValue, CombatCharacter _character)
    {
        trackValue = _trackValue;
        character = _character;
        bar = transform.GetChild(0).GetComponent<Image>();
        character.actionTimer.currentAT.onChange += UpdateBar;
    }
}

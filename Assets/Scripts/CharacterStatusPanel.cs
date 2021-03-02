using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusPanel : MonoBehaviour
{
    public CombatCharacter character;

    [SerializeField] Image portrait;
    [SerializeField] StatusBar hpBar;
    [SerializeField] Value hpValue;
    [SerializeField] Value hpMaxValue;
    [SerializeField] StatusBar mpBar;
    [SerializeField] Value mpValue;
    [SerializeField] Value mpMaxValue;
    [SerializeField] StatusBar atBar;
    [SerializeField] Value atValue;
    [SerializeField] Value atMaxValue;

    internal void Set(CombatCharacter character)
    {
        portrait.sprite = character.character.entity.actor.characterPortrait;
        hpBar.Set(
            character.character.statsContainer.GetValueReference(hpValue),
            character.character.statsContainer.GetValueReference(hpMaxValue)
            );
        mpBar.Set(
            character.character.statsContainer.GetValueReference(mpValue),
            character.character.statsContainer.GetValueReference(mpMaxValue)
            );
        atBar.Set(
            character.actionTimer.currentAT,
            character.actionTimer.targetATRef
            );
    }
}

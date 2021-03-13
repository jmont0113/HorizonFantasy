using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public ActionTimer actionTimer;
    public Character character;
    public List<Ability> abilities;

    public bool Ready
    {
        get 
        {
            return actionTimer.Ready;
        }
    }

    private void Start()
    {
        actionTimer = GetComponent<ActionTimer>();
        character = GetComponent<Character>();
        actionTimer.Init();
        abilities = new List<Ability>(character.abilities);
    }

    internal void TakeDamage(int damage)
    {
        //implement all possible situational conditions specific for combat, here.
        
        character.TakeDamage(damage);
    }

    public void Tick(float _tick)
    {
        actionTimer.Tick(_tick);
    }

    //*TODO* redo this to be more modular and independent from script
    internal float GetFillAmount(Value trackValue)
    {
        return actionTimer.GetFillAmount(trackValue);
    }
}
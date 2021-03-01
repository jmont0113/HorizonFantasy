using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public ActionTimer actionTimer;

    private void Start()
    {
        actionTimer = GetComponent<ActionTimer>();
    }

    public void Init()
    {
        actionTimer.Init();
        actionTimer.myBar.Set(actionTimer.value, this);
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer : MonoBehaviour
{
    public Value value;
    public ValueFloatReference currentAT;
    [SerializeField] float targetAT = 5f;
    public StatusBar myBar;

    public void Init()
    {
        currentAT = new ValueFloatReference(value);
        currentAT.onChange += CheckAT;
    }

    public void Tick(float _tick)
    {
        currentAT.Sum(_tick);   
    }

    internal float GetFillAmount(Value trackValue)
    {
        return currentAT.value / targetAT;
    }

    void CheckAT()
    {
        if(currentAT.value > targetAT)
        {
            Debug.Log("I'm ready for action!");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer : MonoBehaviour
{
    public Value currentATValue;
    [SerializeField] Value targetATValue;
    public ValueFloatReference currentAT;
    public ValueFloatReference targetATRef;
    [SerializeField] float targetAT = 5f;

    public void Init()
    {
        currentAT = new ValueFloatReference(currentATValue);
        currentAT.onChange += CheckAT;
        targetATRef = new ValueFloatReference(targetATValue, targetAT);
        targetATRef.onChange += CheckAT;
    }

    public void Tick(float _tick)
    {
        currentAT.Sum(_tick);   
    }

    internal float GetFillAmount(Value trackValue)
    {
        return currentAT.value / targetATRef.value;
    }

    void CheckAT()
    {
        if(currentAT.value > targetATRef.value)
        {
            Debug.Log("I'm ready for action!");
        }
    }
}

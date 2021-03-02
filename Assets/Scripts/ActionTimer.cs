using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer : MonoBehaviour
{
    
    public ValueFloatReference currentAT;
    public ValueFloatReference targetATRef;
    [SerializeField] float targetAT = 5f;

    public bool Ready 
    { 
        get
        {
            return currentAT.value > targetATRef.value;
        }
    }

    public void Init()
    {
        currentAT = new ValueFloatReference(null);
        currentAT.onChange += CheckAT;
        targetATRef = new ValueFloatReference(null, targetAT);
        targetATRef.onChange += CheckAT;
        currentAT.value += UnityEngine.Random.value * 2.5f;
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

    internal void Reset()
    {
        currentAT.value = 0f;
    }
}

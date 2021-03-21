using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currencies : MonoBehaviour
{
    [SerializeField] ValueStructure currenciesStructure;
    StatsContainer currencies;

    private void Start()
    {
        currencies = new StatsContainer();
        currenciesStructure.Copy(ref currencies);
    }

    public void Subtract(Value value, int amount)
    {
        currencies.Subtract(value, amount);
    }

    public void Sum(Value value, int amount)
    {
        currencies.Sum(value, amount);
    }

    public int Get(Value value)
    {
        int i;
        currencies.Get(value, out i);
        return i;
    }

    public bool Check(Value value, int amount)
    {
        int i = 0;
        currencies.Get(value, out i);
        return i >= amount;
    }

    internal void Sum(StatsContainer totalReward)
    {
        for(int i = 0; i < currenciesStructure.Values.Count; i++)
        {
            int amount = 0;
            totalReward.Get(currenciesStructure.Values[i], out amount);
            Sum(currenciesStructure.Values[i], amount);
        }
    }
}

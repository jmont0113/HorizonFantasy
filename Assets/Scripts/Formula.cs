using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Formula : ScriptableObject
{
    public abstract List<Value> GetRefereneces();
}

public abstract class FormulaInt : Formula
{
    public abstract int Calculate(StatsContainer stats);
    public virtual void Apply(StatsContainer statsContainer, int amount)
    {

    }
}

public abstract class FormulaFloat : Formula
{
    public abstract float Calculate(StatsContainer stulaats);
    public virtual void Apply(StatsContainer statsContainer, float amount)
    {

    }
}
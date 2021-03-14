using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Formula : ScriptableObject
{
    public virtual List<Value> GetRefereneces() { return null; }
}

public abstract class FormulaInt : Formula
{
    public virtual int Calculate(StatsContainer stats) { return 0; }
    public virtual void Apply(StatsContainer statsContainer, ref int amount) { }
}

public abstract class FormulaFloat : Formula
{
    public virtual float Calculate(StatsContainer stulaats) { return 0; }
    public virtual void Apply(StatsContainer statsContainer, ref float amount) { }
}
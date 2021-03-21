using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formula/EXP")]
public class EXPFormula : FormulaInt
{
    [SerializeField] Value levelValue;
    [SerializeField] int baseExpAmountPerLevel = 1000;
    public override int Calculate(StatsContainer stats)
    {
        int level = 0;
        stats.Get(levelValue, out level);
        return baseExpAmountPerLevel * level;
    }
}

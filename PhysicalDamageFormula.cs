using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formula/Physical Damage")]
public class PhysicalDamageFormula : FormulaInt
{
    public override int Calculate(StatsContainer stats)
    {
        throw new System.NotImplementedException();
    }

    [SerializeField] Value hp;
    public override void Apply(StatsContainer statsContainer, int amount)
    {

    }
}

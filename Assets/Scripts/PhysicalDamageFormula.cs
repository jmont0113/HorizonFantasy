using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Formula/Physical Damage")]
public class PhysicalDamageFormula : FormulaInt
{
    [SerializeField] Value str;
    [SerializeField] int maxFlatDamage;
    public override int Calculate(StatsContainer stats)
    {
        int damage = 0;
        stats.Get(str, out damage);
        damage += Random.Range(0, maxFlatDamage);
        //add critical chance calculation
        //add some kinda other thing etc etc
        return damage;
    }

    [SerializeField] Value hp;
    [SerializeField] Value defense;
    public override void Apply(StatsContainer statsContainer, ref int amount)
    {
        int d = 0;
        statsContainer.Get(defense, out d);
        amount -= d;
        if (amount < 0) { amount = 0; }
        statsContainer.Subtract(hp, amount);
    }
}

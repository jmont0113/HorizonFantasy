using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Formula/Heal")]
public class HealFormula : FormulaInt
{
    [SerializeField] Value hp;
    [SerializeField] Value maxHp;

    public override void Apply(StatsContainer statsContainer, ref int amount)
    {
        ValueIntReference currHPReference = (ValueIntReference)statsContainer.GetValueReference(hp);
        int newHp = currHPReference.value + amount;
        ValueIntReference maxHPReference = (ValueIntReference)statsContainer.GetValueReference(maxHp);
        if(newHp > maxHPReference.value)
        {
            newHp = maxHPReference.value;
        }
        currHPReference.Set(newHp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Formula/HP")]
public class HPFormula : FormulaInt
{
    //Vitality * 6 + Strength * 2 + 30
    public Value vitality;
    int vit;
    public Value strength;
    int str;

    public override int Calculate(StatsContainer stats)
    {
        stats.Get(vitality, out vit);
        stats.Get(strength, out str);
        Debug.Log(str);
        Debug.Log(vit);
        Debug.Log(vit * 6 + str * 2 + 30);
        return vit * 6 + str * 2 + 30; //or you can store it into variable and return, that is up to you.
    }

    public override List<Value> GetRefereneces()
    {
        throw new System.NotImplementedException();
    }

    /*
    public override List<Value> GetReferences()
    {
        List<Value> values = new List<Value>();
        values.Add(vitality);
        values.Add(strength);
        return values;
    }
    */

}

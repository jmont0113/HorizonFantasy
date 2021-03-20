using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Container")]
public class ValueContainer : ValueStructure
{
    public int[] integers;
    public float[] floats;

    internal void Form(ValueStructure statsStructure)
    {
        copyOf = statsStructure;

        integers = new int[copyOf.Values.FindAll(x => x.GetType() == typeof(ValueInt)).Count];
        floats = new float[copyOf.Values.FindAll(x => x.GetType() == typeof(ValueFloat)).Count];
    }

    public override void Copy(ref StatsContainer container)
    {
        int intIndex = 0;
        int floatIndex = 0;

        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] is ValueFloat)
            {
                container.Sum(Values[i], floats[floatIndex]);
                floatIndex++;
            }
            if (Values[i] is ValueInt)
            {
                container.Sum(Values[i], integers[intIndex]);
                intIndex++;
            }
        }
    }
}

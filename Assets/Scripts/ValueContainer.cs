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
        if(values == null)
        {
            values = new List<Value>();
        }
        for (int i = 0; i < statsStructure.values.Count; i++)
        {
            values.Add(statsStructure.values[i]);
        }

        integers = new int[values.FindAll(x =>x.GetType() == typeof(ValueInt)).Count];
        floats = new float[values.FindAll(x => x.GetType() == typeof(ValueFloat)).Count];
    }
}

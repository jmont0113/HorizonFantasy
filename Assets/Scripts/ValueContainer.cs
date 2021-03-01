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

        integers = new int[copyOf.values.FindAll(x =>x.GetType() == typeof(ValueInt)).Count];
        floats = new float[copyOf.values.FindAll(x => x.GetType() == typeof(ValueFloat)).Count];
    }
}

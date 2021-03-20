using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Structure")]
public class ValueStructure : ScriptableObject
{
    [HideInInspector]
    public ValueStructure copyOf;
    public List<Value> values;

    public List<Value> Values 
    { 
        get
        {
            if(copyOf != null)
            {
                return copyOf.values;
            }
            return values;
        }
        set => values = value; 
    }
}

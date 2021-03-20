using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value/Structure")]
public class ValueStructure : ScriptableObject
{
    [HideInInspector]
    public ValueStructure copyOf;
    [SerializeField] List<Value> values;

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

    public virtual void Copy(ref StatsContainer container)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i] is ValueFloat)
            {
                container.valueList.Add(new ValueFloatReference(values[i], 0f));
            }
            if (values[i] is ValueInt)
            {
                container.valueList.Add(new ValueIntReference(values[i], 0));            }
        }
    }
}

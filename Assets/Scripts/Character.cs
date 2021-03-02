using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer
{
    public List<ValueReference> valueList;

    public StatsContainer()
    {
        valueList = new List<ValueReference>();
    }

    internal string GetText(Value value)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        return valueReference.TEXT;
    }

    public void Sum(Value value, int sum)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        if (valueReference != null)
        {
            ValueIntReference reference = (ValueIntReference)valueReference;
            reference.Sum(sum);
        }
        else
        {
            Add(value, sum);
        }
    }

    public  void Sum(ValueContainer stats)
    {
        int integerIndex = 0;
        int floatIndex = 0; 
        for(int i = 0; i < stats.values.Count; i++)
        {
            if(stats.values[i].GetType() == typeof(ValueFloat))
            {
                Sum(stats.values[i], stats.floats[floatIndex]);
                floatIndex++;
            }
            else
            {
                Sum(stats.values[i], stats.integers[integerIndex]);
                integerIndex++;
            }
        }
    }

    public void Subtract(Value value, float sum)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        if (valueReference != null)
        {
            ValueFloatReference reference = (ValueFloatReference)valueReference;
            reference.Subtract(sum);
        }
    }

    public void Subtract(Value value, int sum)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        if (valueReference != null)
        {
            ValueIntReference reference = (ValueIntReference)valueReference;
            reference.Subtract(sum);
        }
    }

    public void Subtract(ValueContainer stats)
    {
        int integerIndex = 0;
        int floatIndex = 0;
        for (int i = 0; i < stats.values.Count; i++)
        {
            if (stats.values[i].GetType() == typeof(ValueFloat))
            {
                Subtract(stats.values[i], stats.floats[floatIndex]);
                floatIndex++;
            }
            else
            {
                Subtract(stats.values[i], stats.integers[integerIndex]);
                integerIndex++;
            }
        }
    }

    public void Get(Value value, out int state)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        ValueIntReference valueInt = (ValueIntReference)valueReference;
        if(valueInt == null)
        {
            state = 0;
        }
        else
        {
            state = valueInt.value;
        }
    }

    public void Get(Value value, out float state)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        ValueFloatReference valueFloat = (ValueFloatReference)valueReference;
        if (valueFloat == null)
        {
            state = 0;
        }
        else
        {
            state = valueFloat.value;
        }
    }

    public ValueReference GetValueReference(Value value)
    {
        return valueList.Find(x => x.valueBase == value);
    }

    public void Subscribe(Action action, Value value)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        valueReference.onChange += action;
    }

    public void Subscribe(Action<Value> action, Value dependency, Value subscribeTo)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == subscribeTo);
        if(valueReference.recalculate == null)
        {
            valueReference.recalculate = action;
        }
        if(valueReference.dependent == null)
        {
            valueReference.dependent = new List<Value>();
        }
        valueReference.dependent.Add(dependency);
    }

    public void Sum(Value value, float sum)
    {
        ValueReference valueReference = valueList.Find(x => x.valueBase == value);
        if ( valueReference != null)
        {
            ValueFloatReference reference = (ValueFloatReference)valueReference;
            reference.Sum(sum);
        }
        else
        {
            Add(value, sum);
        }
    }

    private void Add(Value v, float sum)
    {
        valueList.Add(new ValueFloatReference(v, sum));
    }

    private void Add(Value v, int sum)
    {
        valueList.Add(new ValueIntReference(v, sum));
    }
}

public class Character : MonoBehaviour
{
    
    public StatsContainer statsContainer;
    public Entity entity;

    void Start()
    {
        
    }

    public void Init(Entity e)
    {
        entity = e;
        Init(entity.stats);
    }

    public void Init(ValueContainer valueContainer)
    {
        InitValues(valueContainer);
        InitFormulas();
    }

    private void InitValues(ValueContainer valueContainer)
    {
        statsContainer = new StatsContainer();
        valueContainer.Copy(ref statsContainer);
    }

    private void InitFormulas()
    {
        foreach(ValueReference valueReference in statsContainer.valueList)
        {
            if (valueReference.valueBase.formula)
            {
                valueReference.Null();
                if (valueReference.valueBase.formula is FormulaInt)
                {
                    FormulaInt formula = (FormulaInt)valueReference.valueBase.formula;
                    statsContainer.Sum(valueReference.valueBase, formula.Calculate(statsContainer));
                }
                else
                {
                    FormulaFloat formula = (FormulaFloat)valueReference.valueBase.formula;
                    statsContainer.Sum(valueReference.valueBase, formula.Calculate(statsContainer));
                }
                List<Value> references = valueReference.valueBase.formula.GetReferences();
                for (int i = 0; i < references.Count; i++)
                {
                    statsContainer.Subscribe(ValueRecalculate, valueReference.valueBase, references[i]);
                }
            }
        }
    }

    public void ValueRecalculate(Value value)
    {
       ValueReference valueReference = statsContainer.GetValueReference(value);
        valueReference.Null();
        //Add up all the relevant sources of stats.
        if (valueReference.valueBase.formula is FormulaInt)
        {
            FormulaInt formula = (FormulaInt)valueReference.valueBase.formula;
            statsContainer.Sum(valueReference.valueBase, formula.Calculate(statsContainer));
        }
        else
        {
            FormulaFloat formula = (FormulaFloat)valueReference.valueBase.formula;
            statsContainer.Sum(valueReference.valueBase, formula.Calculate(statsContainer));
        }

    }
}

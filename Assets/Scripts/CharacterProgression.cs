using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProgression : MonoBehaviour
{
    [SerializeField] ValueStructure valueStructure;
    StatsContainer progression;

    void Start()
    {
        progression = new StatsContainer();
        valueStructure.Copy(ref progression);
        progression.Sum(levelValue, 1);
        progression.Subscribe(CheckExp, expValue);
    }

    public void AddRewards(StatsContainer rewardContainer)
    {
        for(int i = 0; i < valueStructure.Values.Count; i++)
        {
            if(valueStructure.Values[i] is ValueInt)
            {
                int a = 0;
                rewardContainer.Get(valueStructure.Values[i], out a);
                progression.Sum(valueStructure.Values[i], a);
            }
            else if (valueStructure.Values[i] is ValueFloat)
            {
                float a = 0f;
                rewardContainer.Get(valueStructure.Values[i], out a);
                progression.Sum(valueStructure.Values[i], a);
            }
        }
    }

    [SerializeField] Value expValue;
    [SerializeField] Value levelValue;
    [SerializeField] FormulaInt expFormula;
    public void CheckExp()
    {
        int exp;
        progression.Get(expValue, out exp);
        if (exp > expFormula.Calculate(progression))
        {
            LevelUP();
        }
    }

    Character character;
    private void LevelUP()
    {
        progression.Sum(levelValue, 1);
        Debug.Log("You have leveled up");
        if(character == null)
        {
            character = gameObject.GetComponent<Character>();
        }
        character.LevelUP();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellTargetArea
{ 
    Single,
    Row,
    FullMap,
    Yourself
}

public abstract class Ability : ScriptableObject
{
    public string Name;
    public SpellTargetArea spellTargetArea;
    public Value source;
    public int cost;
    public string animationName = "Attack";

    abstract public void Activate(CombatCharacter caster, List<CombatCharacter> targets);
    virtual public bool Check(CombatCharacter caster)
    {
        return true;
    }
}

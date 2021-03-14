using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability/Base/Heal")]
public class Heal : Ability
{
    [SerializeField] int amount;
    public override void Activate(CombatCharacter caster, List<CombatCharacter> targets)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].Heal(amount);
        }
    }
}

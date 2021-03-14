using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Base/Attack")]
public class Attack : Ability
{
    [SerializeField] FormulaInt damageFormula;

    public override void Activate(CombatCharacter caster, List<CombatCharacter> targets)
    {
        foreach(CombatCharacter c in targets)
        {
            int damage = damageFormula.Calculate(caster.character.statsContainer);
            c.TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Base/Attack")]
public class Attack : Ability
{
    [SerializeField] int damage = 100;

    public override void Activate(CombatCharacter caster, List<CombatCharacter> targets)
    {
        foreach(CombatCharacter c in targets)
        {
            c.TakeDamage(damage);
        }
    }
}

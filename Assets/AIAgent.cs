using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public int SelectAbility()
    {
        return 0;
    }

    internal List<CombatCharacter> SelectTargets(Ability ability, CombatCharacter caster, CombatLoop loop)
    {
        List<CombatCharacter> targets = new List<CombatCharacter>();

        switch (ability.spellTargetArea)
        {
            case SpellTargetArea.Single:
                for(int i = 0; i < loop.allies.Count; i++)
                {
                    if (loop.allies[i].dead == false)
                    {
                        targets.Add(loop.allies[i]);
                        break;
                    }
                }
                break;
            case SpellTargetArea.Row:
                for (int i = 0; i < loop.allies.Count; i++)
                {
                    if (loop.allies[i].dead == false)
                    {
                        targets.Add(loop.allies[i]);
                    }
                }
                break;
            case SpellTargetArea.FullMap:
                for (int i = 0; i < loop.characters.Count; i++)
                {
                    if(loop.characters[i].dead == false)
                    {
                        targets.Add(loop.characters[i]);
                    }
                }
                break;
            case SpellTargetArea.Yourself:
                targets.Add(caster);
                break;
        }
        return targets;
    }
}

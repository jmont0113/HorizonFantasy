using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    Ability ability;
    bool selectTarget;
    [SerializeField] float maxDistance = 80f;
    List<CombatCharacter> targets;
    CombatLoop combat;
    [SerializeField] HighlightController highlightController;
    CombatCharacter caster;

    private void Start()
    {
        targets = new List<CombatCharacter>();
        combat = GetComponent<CombatLoop>();
    }

    public void InitiateAbility(Ability _ability, CombatCharacter _caster)
    {
        ability = _ability;
        selectTarget = true;
        caster = _caster;
    }

    private void Update()
    {
        if(selectTarget == true)
        {
            targets.Clear();

            switch (ability.spellTargetArea)
            {
                case SpellTargetArea.Single:
                    for (int i = 0; i < combat.characters.Count; i++)
                    {
                        Vector2 charPosition
                            = Camera.main.WorldToScreenPoint(combat.characters[i].transform.position);
                        float distance = Vector2.Distance(Input.mousePosition, charPosition);
                        if (distance < maxDistance)
                        {
                            targets.Add(combat.characters[i]);
                            break;
                        }
                    }
                    break;
                case SpellTargetArea.Row:
                    for (int i = 0; i < combat.characters.Count; i++)
                    {
                        Vector2 charPosition
                            = Camera.main.WorldToScreenPoint(combat.characters[i].transform.position);
                        float distance = Vector2.Distance(Input.mousePosition, charPosition);
                        if (distance < maxDistance)
                        {
                            if(combat.allies.Contains(combat.characters[i]) == true)
                            {
                                targets.AddRange(combat.allies);
                            }
                            else
                            {
                                targets.AddRange(combat.enemies);
                            }
                            break;
                        }
                    }
                    break;
                case SpellTargetArea.FullMap:
                    foreach(CombatCharacter combatCharacter in combat.characters)
                    {
                        targets.Add(combatCharacter);
                    }
                    break;
                case SpellTargetArea.Yourself:
                    targets.Add(caster);
                    break;
            }
        }
        if (targets.Count > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Execute();
            }
            highlightController.Highlight(targets);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Finish(false);
        }
    }

    void Finish(bool complete)
    {
        Clear();
        combat.pause = false;
        highlightController.Hide();
        if(complete == true)
        {
            combat.PassTurn();
        }
    }

    void Execute()
    {
        Finish(true);
    }

    void Clear()
    {
        targets.Clear();
        selectTarget = false;
        caster = null;
        ability = null;
    }
}

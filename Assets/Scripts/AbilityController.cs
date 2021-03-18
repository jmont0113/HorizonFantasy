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
        if(_ability.source != null)
        {
            //*TODO* Create and sent message that your character can't afford to cast this ability
            ValueIntReference source =
                (ValueIntReference)_caster.character.statsContainer.GetValueReference(_ability.source);
            if(source.value <= _ability.cost)
            {
                return;
            }
        }

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
            //this will remove everyone who is dead from the list
            targets.RemoveAll(x => x.dead == true);
        }
        if (targets.Count > 0)
        {
            highlightController.Hide();
            highlightController.Highlight(targets);
            if (Input.GetMouseButtonDown(0))
            {
                Execute();
            }
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
        ability.Activate(caster, targets);
        caster.Play(ability.animationName);

        if (ability.source != null)
        {
            caster.character.statsContainer.Subtract(ability.source, ability.cost);
        }

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

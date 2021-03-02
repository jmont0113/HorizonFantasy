using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField] List<AbilityButton> abilitiesButtons;
    [SerializeField] CombatLoop combatLoop;

    public void Set(List<Ability> a)
    {
        for(int i = 0; i < abilitiesButtons.Count; i++)
        {
            if(i < a.Count)
            {
                abilitiesButtons[i].gameObject.SetActive(true);
                abilitiesButtons[i].Set(a[i]);
            }
            else
            {
                abilitiesButtons[i].gameObject.SetActive(false);
            }
        }
    }

    internal void Use(int id)
    {
        combatLoop.ActivateAbility(id);
    }

    public void Show(bool s)
    {
        gameObject.SetActive(s);
    }
}

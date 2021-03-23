using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyControlManager : MonoBehaviour
{
    CombatCharacter selectedCombatCharacter;
    [HideInInspector]
    public Character selectedCharacter;
    [HideInInspector]
    public Inventory inventory;
    //[HideInInspector]
    public Equipment equipment;

    Party party;

    List<ElementsPanel> panels;

    void Awake()
    {
        party = GameManager.instance.character.GetComponent<Party>();
        inventory = GameManager.instance.character.GetComponent<Inventory>();
        SelectCharacter(party.members[0]);
    }

    internal void Cycle(int v)
    {
        int index = party.members.IndexOf(selectedCombatCharacter);
        index += v;

        if(index < 0)
        {
            index = party.members.Count - 1;
        }
        if (index >= party.members.Count)
        {
            index = 0;
        }

        SelectCharacter(party.members[index]);
    }

    private void SelectCharacter(CombatCharacter combatCharacter)
    {
        selectedCombatCharacter = combatCharacter;
        selectedCharacter = combatCharacter.GetComponent<Character>();
        equipment = combatCharacter.GetComponent<Equipment>();
        UpdatePanels();
    }

    public void UpdatePanels()
    {
        if(panels == null) { return; }
        for(int i = 0; i < panels.Count; i++)
        {
            panels[i].UpdateElements();
        }
    }

    internal void AddPanel(ElementsPanel elementsPanel)
    {
        if(panels == null)
        {
            panels = new List<ElementsPanel>();
        }
        panels.Add(elementsPanel);
    }
}

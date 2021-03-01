using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    List<CombatCharacter> characters;

    public void Init(Party party)
    {
        characters = new List<CombatCharacter>();
        foreach(CombatCharacter character in party.members)
        {
            characters.Add(character);
            character.Init();
        }
    }

    private void Update()
    {
        if(characters == null)
        {
            return;
        }

        float tick = Time.deltaTime;

        foreach(CombatCharacter c in characters)
        {
            c.Tick(tick);
        }
    }
}

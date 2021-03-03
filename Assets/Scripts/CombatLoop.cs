using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    public List<CombatCharacter> characters;
    public List<CombatCharacter> enemies;
    public List<CombatCharacter> allies;
    List<CombatCharacter> awaitingActionQueue;
    [SerializeField] AbilityPanel abilityPanel;
    [SerializeField] HighlightController highlightController;
    public bool pause;
    AbilityController abilityController;

    private void Start()
    {
        abilityController = GetComponent<AbilityController>();
        characters = null;
    }

    public void Init(Party _party, List<CombatCharacter> _enemies)
    {
        characters = new List<CombatCharacter>();
        allies = new List<CombatCharacter>();
        foreach(CombatCharacter character in _party.members)
        {
            characters.Add(character);
            allies.Add(character);
        }

        enemies = new List<CombatCharacter>();
        //for testing 
        //List<Vector3> enemyPos = new List<Vector3>();
        foreach (CombatCharacter character in _enemies)
        {
            characters.Add(character);
           // enemyPos.Add(character.transform.position);
            enemies.Add(character);
        }
        //highlightController.Highlight(enemyPos);

        awaitingActionQueue = new List<CombatCharacter>();
    }

    public void ActivateAbility(int id)
    {
        string str = awaitingActionQueue[0].character.entity.Name
            + " casts: "
            + awaitingActionQueue[0].abilities[id].Name;
        Debug.Log(str);
        GameManager.instance.screenMessage.ShowMessage(
            awaitingActionQueue[0].character.transform.position,
            str
            );
        abilityController.InitiateAbility(awaitingActionQueue[0].abilities[id], awaitingActionQueue[0]);
        abilityPanel.Show(false);
        pause = true;
    }

    internal void PassTurn()
    {
        pause = false;
        awaitingActionQueue[0].actionTimer.Reset();
        awaitingActionQueue.RemoveAt(0);
    }

    private void Update()
    {
        if(characters == null)
        {
            return;
        }

        if(pause == true)
        {
            return;
        }

        if(awaitingActionQueue.Count > 0)
        {
            if(abilityPanel.gameObject.activeInHierarchy == false)
            {
                abilityPanel.Set(awaitingActionQueue[0].abilities);
                abilityPanel.Show(true);
            }

            return;
        }

        float tick = Time.deltaTime;

        foreach(CombatCharacter c in characters)
        {
            if(c.Ready)
            {
                if(awaitingActionQueue.Contains(c) == false)
                {
                    awaitingActionQueue.Add(c);
                }
            }

            c.Tick(tick);
        }
    }
}

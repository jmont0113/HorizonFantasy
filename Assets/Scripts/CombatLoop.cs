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
    [SerializeField] GameObject winCanvas;
    [SerializeField] WinConditionCanvasController winCanvasController;

    private void Start()
    {
        abilityController = GetComponent<AbilityController>();
        characters = null;
    }

    public void Init(Party _party, List<CombatCharacter> _enemies)
    {
        pause = false;

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
        /*GameManager.instance.onScreenMessage.ShowMessage(
           awaitingActionQueue[0].character.transform.position,
            str
            );
        Debug.Log(awaitingActionQueue[0].character.entity.Name
            + " casts: "
            + awaitingActionQueue[0].abilities[id].Name);
        */

        abilityPanel.Show(false);
        pause = true;

        abilityController.InitiateAbility(awaitingActionQueue[0].abilities[id], awaitingActionQueue[0]);
    }

    internal void PassTurn()
    {
        pause = false;
        awaitingActionQueue[0].actionTimer.ResetTimer();
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

        CheckCombatCondition();

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

    private void CheckCombatCondition()
    {
        if (CheckLoseCondition())
        {
            GameManager.instance.gameOverManager.GameOver();
            Debug.Log("You lost the battle");
            pause = true;
        }
        if(CheckWinCondition())
        {
            WinCombat();
            Debug.Log("You won the battle");
            pause = true;
        }
    }

    public void WinCombat()
    {
        StatsContainer totalReward = new StatsContainer();

        for(int i = 0; i < enemies.Count; i++)
        {
            totalReward.Sum(enemies[i].character.entity.reward.rewards);
        }

        GameManager.instance.currencies.Sum(totalReward);

        for(int i = 0; i < allies.Count; i++)
        {
            allies[i].GetComponent<CharacterProgression>().AddRewards(totalReward);
        }

        winCanvasController.Set(totalReward);

        winCanvas.SetActive(true);
    }

    bool CheckLoseCondition()
    {
        for(int i = 0; i < allies.Count; i++)
        {
            if(allies[i].dead == false)
            {
                //if someone out of allies is alive that means you still did not lost the battle
                return false;
            }
        }
        return true;
    }

    bool CheckWinCondition()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].dead == false)
            {
                //if someone out of enemies is alive that means you still did not won the battle
                return false;
            }
        }
        return true;
    }
}

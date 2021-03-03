using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLoop : MonoBehaviour
{
    List<CombatCharacter> characters;
    List<CombatCharacter> awaitingActionQueue;
    [SerializeField] AbilityPanel abilityPanel;
    [SerializeField] HighlightController highlightController;

    public void Init(Party party, List<CombatCharacter> enemies)
    {
        characters = new List<CombatCharacter>();
        foreach(CombatCharacter character in party.members)
        {
            characters.Add(character);
        }

        //for testing 
        List<Vector3> enemyPos = new List<Vector3>();
        foreach (CombatCharacter character in enemies)
        {
            characters.Add(character);
            enemyPos.Add(character.transform.position);
        }
        highlightController.Highlight(enemyPos);

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

        awaitingActionQueue[0].actionTimer.Reset();
        awaitingActionQueue.RemoveAt(0);

        abilityPanel.Show(false);
    }

    private void Update()
    {
        if(characters == null)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] CombatArena defaultArena;
    [SerializeField] CombatLoop combatLoop;
    [SerializeField] SceneManage sceneManage;

    public void InitiateCombat(EnemyEncounter encounter, Party party, CombatArena arena = null)
    {
        if(arena == null)
        {
            arena = defaultArena;
        }

        GameManager.instance.SetControlScheme(ControlScheme.Combat);
        CameraController camera = Camera.main.GetComponent<CameraController>();
        camera.ChangeTarget(arena.cameraPivot, 0f, 0f, true);

        List<CombatCharacter> enemies = new List<CombatCharacter>();
        for(int i = 0; i < encounter.enemies.Count; i++)
        {
            //Quaternion.Euler(0f, 180f, 0f) or Quaternion.identity
            GameObject go = Instantiate(encounter.enemies[i].model, arena.enemySpawnPoints[i].position, Quaternion.Euler(0f, 180f, 0f));
            enemies.Add(go.AddComponent<CombatCharacter>());
            Character character = go.AddComponent<Character>();
            character.Init(encounter.enemies[i]);
            go.AddComponent<ActionTimer>();
        }

        for(int i = 0; i < party.members.Count; i++)
        {
            party.members[i].transform.position = arena.characterSpawnPoints[i].position;
        }

        sceneManage.Set(false);
        combatLoop.Init(party, enemies);
    }
}

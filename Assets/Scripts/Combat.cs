using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] CombatArena defaultArena;
    public void InitiateCombat(EnemyEncounter encounter, Party party, CombatArena arena = null)
    {
        if(arena == null)
        {
            arena = defaultArena;
        }

        GameManager.instance.SetControlScheme(ControlScheme.Combat);
        CameraController camera = Camera.main.GetComponent<CameraController>();
        camera.ChangeTarget(arena.cameraPivot, 0f, 0f);
       
        for(int i = 0; i < encounter.enemies.Count; i++)
        {
            Instantiate(encounter.enemies[i].model, arena.enemySpawnPoints[i].position, Quaternion.identity);
        }

        for(int i = 0; i < party.members.Count; i++)
        {
            party.members[i].transform.position = arena.characterSpawnPoints[i].position;
        }
    }
}

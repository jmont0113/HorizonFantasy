using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] CombatArena defaultArena;
    [SerializeField] CombatLoop combatLoop;
    [SerializeField] SceneManage sceneManage;
    [SerializeField] GameObject enemyPrefab;
    GameObject enemyGroup;
    public AudioSource battleMusic;
    public AudioSource VictoryMusic;

    public void InitiateCombat(EnemyEncounter encounter, Party party, CombatArena arena = null)
    {
        if(arena == null)
        {
            arena = defaultArena;
            battleMusic.Play();
        }

        GameManager.instance.SetControlScheme(ControlScheme.Combat);
        CameraController camera = Camera.main.GetComponent<CameraController>();
        //camera.ChangeTarget(arena.cameraPivot, 0f, 0f, true);
        camera.ChangeTarget(arena.cameraPivot, 0f, 0f);
        camera.InheritRotation(arena.cameraPivot, false);

        List<CombatCharacter> enemies = new List<CombatCharacter>();
        for(int i = 0; i < encounter.enemies.Count; i++)
        {
            //Quaternion.Euler(0f, 180f, 0f) or Quaternion.identity
            GameObject enemy = Instantiate(enemyPrefab, 
                arena.enemySpawnPoints[i].position,
                arena.enemySpawnPoints[i].rotation);

            GameObject go = Instantiate(encounter.enemies[i].model, 
                arena.enemySpawnPoints[i].position,
                arena.enemySpawnPoints[i].rotation);

            go.transform.SetParent(enemy.transform);

            enemies.Add(enemy.GetComponent<CombatCharacter>());
            Character character = enemy.GetComponent<Character>();
            character.Init(encounter.enemies[i]);
        }

        for(int i = 0; i < party.members.Count; i++)
        {
            party.members[i].transform.position = arena.characterSpawnPoints[i].position;
        }

        sceneManage.Set(false);
        combatLoop.Init(party, enemies);
    }

    public void SetEnemyGroup(GameObject enemyGroup)
    {
        this.enemyGroup = enemyGroup;
    }

    public void ExitCombat()
    {
        for (int i = 0; i < combatLoop.enemies.Count; i++)
        {
            Destroy(combatLoop.enemies[i].gameObject);
            battleMusic.Stop();
            VictoryMusic.Play();
        }

        

        GameManager.instance.SetControlScheme(ControlScheme.Exploration);

        CameraController camera = Camera.main.GetComponent<CameraController>();
        //camera.ChangeTarget(GameManager.instance.cameraCharacterPivot, 7f, 0.2f, true);
        camera.ChangeTarget(GameManager.instance.character.transform, 7f, 0.2f);
        camera.InheritRotation(GameManager.instance.cameraCharacterPivot, true);
        camera.Warp(GameManager.instance.character.transform.position, true);

        combatLoop.enemies = null;
        combatLoop.allies = null;
        combatLoop.characters = null;

        sceneManage.Set(true);

        if(enemyGroup != null)
        {
            Destroy(enemyGroup);
            enemyGroup = null;
        }
    }
}

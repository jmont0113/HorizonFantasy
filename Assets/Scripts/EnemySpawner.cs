using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    EnemySpawnerContainer container;
    public float wanderingDistance = 5f;

    private void Start()
    {
        container = transform.parent.GetComponent<EnemySpawnerContainer>();

        if(container == null) { Debug.LogWarning("No EnemySpawnerContainer has been referenced! EnemySpawner will not spawn enemies!"); }

        Spawn();
    }

    private void Spawn()
    {
        if(container == null) { return; }
        //Quaternion.Euler(0f, 180f, 0f) or Quaternion.identity
        GameObject go = Instantiate(container.enemyGroupPrefab, transform.position, Quaternion.identity);
        go.transform.parent = transform;
        EnemyGroup enemyGroup = go.GetComponent<EnemyGroup>();
        enemyGroup.spawnPoint = transform;
        enemyGroup.encounter = container.GetEncounter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "EnemySpawner.png", false);
    }
}

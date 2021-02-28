using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerContainer : MonoBehaviour
{
    public EncounterList encounterList;
    public GameObject enemyGroupPrefab;

    public EnemyEncounter GetEncounter()
    {
        if(encounterList == null) { return null; }

        int i = UnityEngine.Random.Range(0, encounterList.encounters.Count);
        return encounterList.encounters[i];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Encounter List")]
public class EncounterList : ScriptableObject
{
    public List<EnemyEncounter> encounters;
}

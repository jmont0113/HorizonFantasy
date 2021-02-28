using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Encounter")]
public class EnemyEncounter : ScriptableObject
{
    public List<Enemy> enemies;
}

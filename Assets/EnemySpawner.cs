using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   private void OnDrawGizmos()
   {
        Gizmos.DrawIcon(transform.position, "EnemySpawner", false);
   }
}

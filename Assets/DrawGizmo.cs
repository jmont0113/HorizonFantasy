using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField] Color tint;

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Diamond.png", false, tint);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    Editor valueEditor;

    private void OnEnable()
    {
        valueEditor = CreateEditor(serializedObject.FindProperty("stats").objectReferenceValue, typeof(ValueContainerEditor));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        valueEditor = CreateEditor(serializedObject.FindProperty("stats").objectReferenceValue, typeof(ValueContainerEditor));
        if (valueEditor != null)
        {
            valueEditor.OnInspectorGUI();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

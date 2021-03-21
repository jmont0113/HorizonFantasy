using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity))]
public class EnemyEditor : Editor
{
    Editor valueEditor;
    Editor growthEditor;

    private void OnEnable()
    {
        valueEditor = CreateEditor(
            serializedObject.FindProperty("stats").objectReferenceValue, 
            typeof(ValueContainerEditor)
            );

        growthEditor = CreateEditor(
            serializedObject.FindProperty("statsGrowth").objectReferenceValue, 
            typeof(ValueContainerEditor)
            );
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        valueEditor = CreateEditor(serializedObject.FindProperty("stats").objectReferenceValue, typeof(ValueContainerEditor));
        if (valueEditor != null)
        {
            GUILayout.Label("Base Stats");
            valueEditor.OnInspectorGUI();
        }

        growthEditor = CreateEditor(
           serializedObject.FindProperty("statsGrowth").objectReferenceValue,
           typeof(ValueContainerEditor)
           );

        if(growthEditor != null)
        {
            GUILayout.Label("Growth Stats");
            growthEditor.OnInspectorGUI();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RewardContainer))]
public class RewardEditor : Editor
{
    Editor valueEditor;
    
    private void OnEnable()
    {
        valueEditor = CreateEditor(
            serializedObject.FindProperty("rewards").objectReferenceValue, 
            typeof(ValueContainerEditor)
            );
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        valueEditor = CreateEditor(
            serializedObject.FindProperty("rewards").objectReferenceValue, 
            typeof(ValueContainerEditor)
            );

        if (valueEditor != null)
        {
            valueEditor.OnInspectorGUI();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

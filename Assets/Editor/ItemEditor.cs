using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
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
        if(valueEditor != null)
        {
            valueEditor.OnInspectorGUI();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

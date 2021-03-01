using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(ValueContainer))]
public class ValueContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty copyOf = serializedObject.FindProperty("copyOf");
        if(copyOf.objectReferenceValue == null)
        {
            Show(serializedObject.FindProperty("values"));
        }
        else
        {
            SerializedObject so = new SerializedObject(serializedObject.FindProperty("copyOf").objectReferenceValue);
            Show(so.FindProperty("values"));
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void Show(SerializedProperty list)
    {
        integerIndex = 0;
        floatIndex = 0;
        EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));

        for(int i = 0; i < list.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            SerializedProperty sp = list.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(sp, GUIContent.none);
            ShowState(i, sp);
            EditorGUILayout.EndHorizontal();
        }
    }

    int integerIndex = 0;
    int floatIndex = 0;

    private void ShowState(int i, SerializedProperty sp)
    {
        if(sp.objectReferenceValue == null) { return; }
        if(sp.objectReferenceValue.GetType() == typeof(ValueInt))
        {
            ShowValueField("integers", integerIndex);
            integerIndex += 1;
        }
        else
        {
            ShowValueField("floats", floatIndex);
            floatIndex += 1;
        }
    }

    private void ShowValueField(string valueArray, int index)
    {
        SerializedProperty list = serializedObject.FindProperty(valueArray);
        if(index >= list.arraySize)
        {
            list.arraySize += 1;
        }
        SerializedProperty arrayElement = list.GetArrayElementAtIndex(index);
        if(arrayElement != null)
        {
            EditorGUILayout.PropertyField(arrayElement, GUIContent.none);
        }
    }
}

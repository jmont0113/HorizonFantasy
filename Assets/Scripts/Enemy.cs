using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class Enemy : ScriptableObject
{
    public string Name;
    public GameObject model;
    public ValueContainer stats;

    [MenuItem("Assets/Create/Data/Enemy")]
    static void CreateInstance()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if(path == "")
        {
            path = "Assets";
        }
        else if(Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        Enemy e = CreateInstance<Enemy>();
        AssetDatabase.CreateAsset(e, AssetDatabase.GenerateUniqueAssetPath(path + "/Enemy.asset"));
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(e));

        e.stats = CreateInstance<ValueContainer>();
        AssetDatabase.AddObjectToAsset(e.stats, e);
        e.stats.name = "Enemy Stats";
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(e.stats));

        ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
        e.stats.Form(statsStructure);
    }
}

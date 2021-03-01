using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class Entity : ScriptableObject
{
    public string Name;
    public GameObject model;
    public ValueContainer stats;

    static Entity CreateEntity(string path)
    {
        Entity e = CreateInstance<Entity>();
        AssetDatabase.CreateAsset(e, AssetDatabase.GenerateUniqueAssetPath(path));
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(e));

        e.stats = CreateInstance<ValueContainer>();
        AssetDatabase.AddObjectToAsset(e.stats, e);
        e.stats.name = "Stats";
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(e.stats));

        ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
        e.stats.Form(statsStructure);
        return e;
    }

    [MenuItem("Assets/Create/Data/Enemy")]
    static void CreateEnemyInstance()
    {
        Entity e = CreateEntity(GetPath() + "/Enemy.asset");
    }

    [MenuItem("Assets/Create/Data/Character")]
    static void CreateCharacterInstance()
    {
        Entity e = CreateEntity(GetPath() + "/Character.asset");
    }

    static string GetPath()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }
        return path;
    }
}

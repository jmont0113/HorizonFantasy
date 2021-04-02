using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Entity : ScriptableObject
{
    public enum EntityType
    {
        None,
        Enemy,
        Character
    }

    public string Name;
    public GameObject model;
    public ValueContainer stats;
    public ValueContainer statsGrowth;
    public Actor actor;
    public RewardContainer reward;
    public List<Ability> abilities;
    [ReadOnly] public EntityType entityType;

    private void OnEnable()
    {
        switch (entityType)
        {
            case EntityType.Enemy:
                if (stats == null)
                {
                    stats = (ValueContainer)Embed(this, typeof(ValueContainer), "Stats");

                    ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
                    stats.Form(statsStructure);
                }

                if(reward == null)
                {
                    reward = (RewardContainer)Embed(this, typeof(RewardContainer), "Reward");
                    reward.rewards = (ValueContainer)Embed(
                        this, 
                        typeof(ValueContainer), 
                        "Reward Values"
                        );

                    ValueStructure rewardsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath(
                        "Assets/Data/Base/Rewards.asset",
                        typeof(ValueStructure)
                        );
                    reward.rewards.Form(rewardsStructure);
                }

                if(reward.rewards.copyOf == null)
                {
                    ValueStructure rewardsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath(
                        "Assets/Data/Base/Rewards.asset",
                        typeof(ValueStructure)
                        );
                    reward.rewards.Form(rewardsStructure);
                }

                break;

            case EntityType.Character:
                if (stats == null)
                {
                    stats = (ValueContainer)Embed(this, typeof(ValueContainer), "Stats");

                    ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
                    stats.Form(statsStructure);
                }
                
                if (actor == null)
                {
                    actor = (Actor)Embed(this, typeof(Actor), "Actor");
                }
                    
                if(statsGrowth == null)
                {
                    statsGrowth = (ValueContainer)Embed(this, typeof(ValueContainer), "Growth");

                    ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
                    statsGrowth.Form(statsStructure);
                }

                break;
        }
    }
    static Entity CreateEntity(string path)
    {
        Entity e = CreateInstance<Entity>();
        AssetDatabase.CreateAsset(e, AssetDatabase.GenerateUniqueAssetPath(path));
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(e));
        
        e.stats = (ValueContainer)Embed(e, typeof(ValueContainer), "Stats");
        
        ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
        e.stats.Form(statsStructure);
        return e;
    }
    
    [MenuItem("Assets/Create/Data/Enemy")]
    static void CreateEnemyInstance()
    {
        Entity e = CreateEntity(GetPath() + "/Enemy.asset");
        e.entityType = EntityType.Enemy;

        e.reward = (RewardContainer)Embed(e, typeof(RewardContainer), "Reward");
        e.reward.rewards = (ValueContainer)Embed(e, typeof(ValueContainer), "Reward Values");
        
        ValueStructure rewardsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath(
            "Assets/Data/Base/Rewards.asset",
            typeof(ValueStructure)
            );
        e.reward.rewards.Form(rewardsStructure);
    }

    [MenuItem("Assets/Create/Data/Character")]
    static void CreateCharacterInstance()
    {
        Entity e = CreateEntity(GetPath() + "/Character.asset");
        e.entityType = EntityType.Character;
        
        //create and embedding an actor instance to the character
        e.actor = (Actor)Embed(e, typeof(Actor), "Actor");

        e.statsGrowth = (ValueContainer)Embed(e, typeof(ValueContainer), "Growth");

        ValueStructure statsStructure = (ValueStructure)AssetDatabase.LoadAssetAtPath("Assets/Data/Base/CharacterStats.asset", typeof(ValueStructure));
        e.statsGrowth.Form(statsStructure);
    }
    
    private static ScriptableObject Embed(UnityEngine.Object e, Type type, string n)
    {
        ScriptableObject so = CreateInstance(type);
        AssetDatabase.AddObjectToAsset(so, e);
        so.name = n;
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(so));
        return so;
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
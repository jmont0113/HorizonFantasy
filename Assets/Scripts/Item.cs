using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public int sell, buy;
    public bool stackable;
    public ItemType itemType;
    public ValueContainer stats;
}

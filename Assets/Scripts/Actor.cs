using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Actor")]
public class Actor : ScriptableObject
{
    public string Name;
    public Texture2D characterPortrait;
}

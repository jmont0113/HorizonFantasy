using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string[] text;
    public Actor[] actor;
}

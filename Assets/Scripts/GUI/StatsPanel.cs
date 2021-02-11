using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField]
    ValueStructure characterStats;
    [SerializeField]
    GameObject text;
    [SerializeField]
    Character character;

    void Start()
    {
        for(int i = 0; i < characterStats.values.Count; i++)
        {
            GameObject newText = Instantiate(text, transform);
            newText.GetComponent<TextCharacterValue>().Set(characterStats.values[i], character);
        }
    }
}

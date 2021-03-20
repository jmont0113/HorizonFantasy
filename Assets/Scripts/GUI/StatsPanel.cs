using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField]
    ValueStructure characterStats;
    [SerializeField]
    GameObject text;

    public void Show(Character character)
    {
        for(int i = 0; i < characterStats.Values.Count; i++)
        {
            GameObject newText = Instantiate(text, transform);
            newText.GetComponent<TextCharacterValue>().Set(characterStats.Values[i], character);
        }
    }
}

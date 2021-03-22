using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : Element
{
    [SerializeField]
    ValueStructure characterStats;
    [SerializeField]
    GameObject text;
    List<TextCharacterValue> texts;

    public override void OnInteract(int id)
    {
        throw new System.NotImplementedException();
    }

    public override void Show(PartyControlManager manager)
    {
        texts = new List<TextCharacterValue>();
        for (int i = 0; i < characterStats.Values.Count; i++)
        {
            GameObject newText = Instantiate(text, transform);
            TextCharacterValue tcv = newText.GetComponent<TextCharacterValue>();
            tcv.Set(
                characterStats.Values[i], 
                manager.selectedCharacter
                );
            texts.Add(tcv);
        }
    }

    public override void UpdateElement(PartyControlManager manager)
    {
        for(int i = 0; i < characterStats.Values.Count; i++)
        {
            texts[i].Set(
                characterStats.Values[i],
                manager.selectedCharacter
                );
        }
    }
}

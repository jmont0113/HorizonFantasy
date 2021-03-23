using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillListPanel : Element
{
    [SerializeField] Text text;

    public override void OnInteract(int id)
    {
        throw new System.NotImplementedException();
    }

    public override void Show(PartyControlManager manager)
    {
        UpdateText(manager);
    }

    public override void UpdateElement(PartyControlManager manager)
    {
        UpdateText(manager);
    }

    void UpdateText(PartyControlManager manager)
    {
        text.text = "";
        for (int i = 0; i < manager.selectedCharacter.abilities.Count; i++)
        {
            text.text += manager.selectedCharacter.abilities[i].Name + "\n";
        }
    }
}

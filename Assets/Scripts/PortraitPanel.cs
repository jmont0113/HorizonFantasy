using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitPanel : Element
{
    [SerializeField] Text characterName;
    [SerializeField] Image portrait;

    public override void OnInteract(int id)
    {
        throw new System.NotImplementedException();
    }

    public override void Show(PartyControlManager manager)
    {
        characterName.text = manager.selectedCharacter.entity.actor.Name;
        portrait.sprite = manager.selectedCharacter.entity.actor.characterPortrait;
    }

    public override void UpdateElement(PartyControlManager manager)
    {
        characterName.text = manager.selectedCharacter.entity.actor.Name;
        portrait.sprite = manager.selectedCharacter.entity.actor.characterPortrait;
    }
}

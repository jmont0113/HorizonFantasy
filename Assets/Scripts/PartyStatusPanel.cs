using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyStatusPanel : MonoBehaviour
{
    [SerializeField] List<CharacterStatusPanel> statusPanels;
    [SerializeField] Party party;

    private void Start()
    {
        Show();

        for(int i = 0; i < statusPanels.Count; i++)
        {
            if(party.members.Count > i)
            {
                SetPanel(statusPanels[i], party.members[i]);
            }
        }
    }

    void Show()
    {
        for(int i = 0; i < statusPanels.Count; i++)
        {
            statusPanels[i].gameObject.SetActive(i < party.members.Count);
        }
    }

    void SetPanel(CharacterStatusPanel panel, CombatCharacter character)
    {
        panel.Set(character);
    }
}

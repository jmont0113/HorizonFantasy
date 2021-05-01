using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour, IPointerClickHandler
{
    Text text;
    AbilityPanel abilityPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(abilityPanel == null)
        {
            abilityPanel = transform.parent.GetComponent<AbilityPanel>();

        }
        abilityPanel.Use(transform.GetSiblingIndex());
    }

    internal void Set(Ability ability)
    {
        if (text == null)
        {
            text = transform.GetChild(0).GetComponent<Text>();
        }

        text.text = ability.Name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsPanel : Element
{
    [SerializeField] GameObject buttonPrefab;

    List<ItemButton> itemButtons;

    Equipment equipment;

    public override void OnInteract(int id)
    {
        
    }

    public override void UpdateElement(PartyControlManager manager)
    {
        equipment = manager.equipment;
        for(int i = 0; i < itemButtons.Count; i++)
        {
            itemButtons[i].Set(equipment.equipmentSlots[i].equipped, this);
        }
    }

    public override void Show(PartyControlManager manager)
    {
        equipment = manager.equipment;
        itemButtons = new List<ItemButton>();
        for (int i = 0; i < equipment.equipmentSlots.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, transform);
            itemButtons.Add(newButton.GetComponent<ItemButton>());
            itemButtons[i].Set(equipment.equipmentSlots[i].equipped, this);
        }
    }
}

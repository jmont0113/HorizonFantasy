using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsPanel : ItemPanel
{
    List<ItemButton> itemButtons;

    private void OnEnable()
    {
        if(itemButtons == null)
        {
            itemButtons = new List<ItemButton>();
            Show();
            inventoryManager.equipment.onChange += UpdatePanel;
        }
        UpdatePanel();
    }

    public override void OnInteract(int id)
    {
        
    }

    public override void UpdatePanel()
    {
        for(int i = 0; i < itemButtons.Count; i++)
        {
            itemButtons[i].Set(inventoryManager.equipment.equipmentSlots[i].equipped, this);
        }
    }

    public override void Show()
    {
        for (int i = 0; i < inventoryManager.equipment.equipmentSlots.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, transform);
            itemButtons.Add(newButton.GetComponent<ItemButton>());
            itemButtons[i].Set(inventoryManager.equipment.equipmentSlots[i].equipped, this);
        }
    }
}

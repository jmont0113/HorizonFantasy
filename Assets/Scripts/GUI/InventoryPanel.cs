using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    List<ItemButton> buttons;

    public override void OnInteract(int id)
    {
        ItemInstance item = inventoryManager.inventory.GetItem(id);
        if(inventoryManager.equipment.CheckAvailableSlots(item))
        {
            Item previousItem = inventoryManager.equipment.GetItemSlot(item.itemBase.itemType);
            if(previousItem != null)
            {
                inventoryManager.character.statsContainer.Subtract(previousItem.stats);
                inventoryManager.inventory.AddItem(previousItem);
            }
            inventoryManager.character.statsContainer.Sum(item.itemBase.stats);
            inventoryManager.equipment.Equip(item.itemBase);
            inventoryManager.inventory.RemoveItem(item.itemBase);
            UpdatePanel();
        }
    }

    public override void Show()
    {

    }

    public override void UpdatePanel()
    {
        while(buttons.Count > inventoryManager.inventory.GetItemCount)
        {
            Destroy(buttons[0].gameObject);
            buttons.RemoveAt(0);
        }
        for(int i = 0; i < inventoryManager.inventory.GetItemCount; i++)
        {
            if(i >= buttons.Count)
            {
                GameObject newButton = Instantiate(buttonPrefab, transform);
                buttons.Add(newButton.GetComponent<ItemButton>());
            }
            buttons[i].Set(inventoryManager.inventory.GetItem(i), this);
        }
    }

    private void OnEnable()
    {
        if (buttons == null)
        {
            buttons = new List<ItemButton>();
        }
        UpdatePanel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    List<ItemButton> buttons;

    void Start()
    {
        
    }

    public override void OnInteract(int id)
    {
        ItemInstance item = inventoryManager.inventory.GetItem(id);
        if(inventoryManager.equipment.CheckAvailableSlots(item))
        {
            inventoryManager.equipment.Equip(item.itemBase);
            inventoryManager.inventory.RemoveItem(item.itemBase);
            UpdatePanel();
        }
    }

    public override void Show()
    {
        List<ItemInstance> items = inventoryManager.inventory.GetInventory();
        for (int i = 0; i < items.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, transform);
            newButton.GetComponent<ItemButton>().Set(items[i], this);
        }
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

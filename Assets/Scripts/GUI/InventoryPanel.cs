using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : Element
{
    [SerializeField] GameObject buttonPrefab;
    List<ItemButton> buttons;
    private Character character;
    private Equipment equipment;
    private Inventory inventory;

    public override void OnInteract(int id)
    {
        ItemInstance item = inventory.GetItem(id);
        if(equipment.CheckAvailableSlots(item))
        {
            Item previousItem = equipment.GetItemSlot(item.itemBase.itemType);
            if(previousItem != null)
            {
                character.statsContainer.Subtract(previousItem.stats);
                inventory.AddItem(previousItem);
            }
            character.statsContainer.Sum(item.itemBase.stats);
            equipment.Equip(item.itemBase);
            inventory.RemoveItem(item.itemBase);

            onInteract?.Invoke();
        }
    }

    public override void Show(PartyControlManager manager)
    {
        character = manager.selectedCharacter;
        equipment = manager.equipment;
        inventory = manager.inventory;
    }

    public override void UpdateElement(PartyControlManager manager)
    {
        character = manager.selectedCharacter;
        equipment = manager.equipment;
        while (buttons.Count > manager.inventory.GetItemCount)
        {
            Destroy(buttons[0].gameObject);
            buttons.RemoveAt(0);
        }
        for(int i = 0; i < manager.inventory.GetItemCount; i++)
        {
            if(i >= buttons.Count)
            {
                GameObject newButton = Instantiate(buttonPrefab, transform);
                buttons.Add(newButton.GetComponent<ItemButton>());
            }
            buttons[i].Set(manager.inventory.GetItem(i), this);
        }
    }

    private void OnEnable()
    {
        if (buttons == null)
        {
            buttons = new List<ItemButton>();
        }
    }
}

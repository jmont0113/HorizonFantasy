using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
   public Item itemBase;
   public int itemCount;

    public ItemInstance(Item _itemBase, int count = 1)
    {
        itemBase = _itemBase;
        itemCount = count;
    }
}

public class Inventory : MonoBehaviour
{
    List<ItemInstance> inventory;
    [SerializeField]
    List<Item> itemOnStart;

    public int GetItemCount 
    { 
        get { return inventory.Count; }
    }

    void Awake()
    {
        inventory = new List<ItemInstance>();
        for (int i = 0; i < itemOnStart.Count; i++)
        {
            AddItem(itemOnStart[i]);
        }
    }

    public List<ItemInstance> GetInventory()
    {
        return inventory;
    }

    public void AddItem(Item item, int count = 1)
    {
        if(item.stackable)
        {
            ItemInstance itemInstance = inventory.Find(x => x.itemBase == item);
            if(itemInstance == null)
            {
                inventory.Add(new ItemInstance(item));
            }
            else
            {
                itemInstance.itemCount += count;
            }
        }
        else
        {
            inventory.Add(new ItemInstance(item, count));
        }
    }

    public void RemoveItem(Item item, int count = 1)
    {
        ItemInstance itemInstance = inventory.Find(x => x.itemBase == item);
        if(itemInstance == null)
        {
            return;
        }

        if(item.stackable)
        {
            itemInstance.itemCount -= count;
            if(itemInstance.itemCount <= 0)
            {
                inventory.Remove(itemInstance);
            }
        }
        else
        {
            inventory.Remove(itemInstance);
        }
    }

    internal ItemInstance GetItem(int id)
    {
        return inventory[id];
    }
}

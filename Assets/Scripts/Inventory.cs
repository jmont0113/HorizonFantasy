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

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<ItemInstance>();
        for (int i = 0; i < itemOnStart.Count; i++)
        {
            AddItem(itemOnStart[i]);
        }
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

    private void OnGUI()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            string s = i.ToString() + " : " + inventory[i].itemBase.Name + " X "  + inventory[i].itemCount;
            GUI.Label(new Rect(10, 10 + 20 * i, 300, 20), s);
        }
    }
}

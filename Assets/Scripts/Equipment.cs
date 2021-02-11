using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Weapon,
    Armor,
    Accessory
}

public class EquipmentSlot
{
    ItemType itemType;
    public Item equipped;

    public EquipmentSlot(ItemType _itemType)
    {
        itemType = _itemType;
    }

    internal void Equip(Item toEquip)
    {
        equipped = toEquip;

    }
}

public class Equipment : MonoBehaviour
{
    [SerializeField]
    List<ItemType> availableSlots;
    public EquipmentSlot[] equipmentSlots;
    public Action onChange;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        equipmentSlots = new EquipmentSlot[availableSlots.Count];
        for (int i = 0; i < availableSlots.Count; i++)
        {
            equipmentSlots[i] = new EquipmentSlot(availableSlots[i]);
        }
    }

    public void Equip(Item toEquip, int slotNumber)
    {
        equipmentSlots[slotNumber].Equip(toEquip);
    }

    internal bool CheckAvailableSlots(ItemInstance item)
    {
        return availableSlots.Contains(item.itemBase.itemType);
    }

    internal void Equip(Item itemBase)
    {
        int slotNum = availableSlots.FindIndex(x => x == itemBase.itemType);
        Equip(itemBase, slotNum);
        if(onChange != null)
        {
            onChange.Invoke();
        }
    }

    internal Item GetItemSlot(ItemType itemType)
    {
        int slot = availableSlots.FindIndex(x => x == itemType);
        return equipmentSlots[slot].equipped;
    }
}

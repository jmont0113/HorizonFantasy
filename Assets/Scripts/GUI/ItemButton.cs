﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerClickHandler
{
    Element itemPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        itemPanel.OnInteract(transform.GetSiblingIndex());
    }

    public void Set(ItemInstance itemInstance, Element _itemPanel)
    {
        itemPanel = _itemPanel;
        transform.GetChild(0).GetComponent<Text>().text = itemInstance.itemBase.Name + " " + itemInstance.itemCount.ToString();
    }

    public void Set(Item item, Element _itemPanel)
    {
        itemPanel = _itemPanel;
        if(item == null)
        {
            transform.GetChild(0).GetComponent<Text>().text = "Empty";
            return;
        }
        transform.GetChild(0).GetComponent<Text>().text = item.Name;
    }
}

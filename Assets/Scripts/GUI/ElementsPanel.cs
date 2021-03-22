using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPanel : MonoBehaviour
{
    List<Element> elements;
    PartyControlManager manager;

    private void Awake()
    {
        manager = transform.parent.GetComponent<PartyControlManager>();
        manager.AddPanel(this);
    }

    private void Start()
    {
        UpdateElements();
    }

    private void OnEnable()
    {
        if(elements == null) { return; }
        UpdateElements();
    }

    internal void AddMe(Element element)
    {
        if(elements == null)
        {
            elements = new List<Element>();
        }
        elements.Add(element);
        if(manager == null)
        {
            manager = transform.parent.GetComponent<PartyControlManager>();
        }
        element.Show(manager);
        element.onInteract += UpdateElements;
    }

    public void UpdateElements()
    {
        for(int i = 0; i < elements.Count; i++)
        {
            elements[i].UpdateElement(manager);
        }
    }
}

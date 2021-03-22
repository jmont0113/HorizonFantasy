using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public Action onInteract;
    public abstract void OnInteract(int id);
    public abstract void Show(PartyControlManager manager);
    public abstract void UpdateElement(PartyControlManager manager);

    private void Awake()
    {
        transform.GetComponentInParent<ElementsPanel>().AddMe(this);
    }
}

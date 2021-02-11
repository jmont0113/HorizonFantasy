using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPanel : MonoBehaviour
{
    public GameObject buttonPrefab;
    public InventoryManager inventoryManager;
    public abstract void OnInteract(int id);
    public abstract void Show();
    public abstract void UpdatePanel();
}

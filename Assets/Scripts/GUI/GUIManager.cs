using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameObject inventoryCanvas;

    public void OpenInventory(bool open)
    {
        inventoryCanvas.SetActive(open);
    }
}

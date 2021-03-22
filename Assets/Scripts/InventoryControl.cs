using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField] PartyControlManager manager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.guiManager.OpenInventory(false);
            GameManager.instance.SetControlScheme(ControlScheme.Exploration);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            manager.Cycle(-1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            manager.Cycle(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsPanel : ItemPanel
{
    [SerializeField]
    Equipment currCharacter;
    [SerializeField]
    GameObject button;

    void Start()
    {
        Show();
    }

    public override void OnInteract(int id)
    {
        
    }

    public override void Show()
    {
        for (int i = 0; i < currCharacter.equipmentSlots.Length; i++)
        {
            GameObject newButton = Instantiate(button, transform);
            newButton.GetComponent<ItemButton>().Set(currCharacter.equipmentSlots[i].equipped, this);
        }
    }

    public override void UpdatePanel()
    {
        
    }
}

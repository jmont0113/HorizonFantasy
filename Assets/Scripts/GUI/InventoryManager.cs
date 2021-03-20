using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public Equipment equipment;
    public Character character;
    Party party;
    [SerializeField] StatsPanel inventoryStatsPanel;

    private void Awake()
    {
        party = GameManager.instance.character.GetComponent<Party>();
    }

    private void OnEnable()
    {
        character = party.members[0].character;
        equipment = party.members[0].GetComponent<Equipment>();
        UpdateStatsPanel();
    }

    public void UpdateStatsPanel()
    {
        inventoryStatsPanel.Show(character);
    }
}

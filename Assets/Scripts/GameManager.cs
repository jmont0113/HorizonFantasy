using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlScheme
{
    Exploration,
    Inventory,
    Dialogue,
    Combat
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetControlCharacter(character);
    }

    public DialogueManager dialogueManager;
    public CharacterControl characterControl;
    public InventoryControl inventoryControl;
    public DialogueControl dialogueControl;
    public OnScreenMessage onScreenMessage;
    public GameObject character;
    public GUIManager guiManager;
    public Combat combat;
    public GameOverManager gameOverManager;

    void SetControlCharacter(GameObject target)
    {
        characterControl.Init(target);
    }

    private void Update()
    {
        if(character != characterControl.target)
        {
            SetControlCharacter(character);
        }
    }

    public void SetControlScheme(ControlScheme controlScheme)
    {
        switch (controlScheme)
        {
            case ControlScheme.Exploration:
                characterControl.enabled = true;
                inventoryControl.enabled = false;
                dialogueControl.enabled = false;
                break;
            case ControlScheme.Inventory:
                characterControl.enabled = false;
                inventoryControl.enabled = true;
                dialogueControl.enabled = false;
                break;
            case ControlScheme.Dialogue:
                characterControl.enabled = false;
                inventoryControl.enabled = false;
                dialogueControl.enabled = true;
                break;
            case ControlScheme.Combat:
                characterControl.enabled = false;
                inventoryControl.enabled = false;
                dialogueControl.enabled = false;
                break;
        }
    }
}
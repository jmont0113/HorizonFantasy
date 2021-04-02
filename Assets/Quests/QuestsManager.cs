using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    public static QuestsManager questsManager;

    public List<Quests> questList = new List<Quests>();        //Master Quest List
    public List<Quests> currentQuestList = new List<Quests>(); //Current Quest List

    //private vars for our QuestObject
    void Awake()
    {
        if(questsManager == null)
        {
            questsManager = this;
        }
        else if(questsManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //ACCEPT QUEST
    public void AcceptQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quests.QuestProgress.AVAILABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quests.QuestProgress.ACCEPTED;
            }
        }
    }

    //GIVE UP QUEST
    public void GiveUpQuest(int questID)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quests.QuestProgress.AVAILABLE;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }

        }
    }

    //COMPLETE QUEST
    public void CompleteQuest(int questID)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == Quests.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quests.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    //ADD ITEMS
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quests.QuestProgress.COMPLETE;
            }
        }
    }

    //REMOVE ITEMS


    // BOOLS
    public bool RequestAvailableQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quests.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quests.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }
}

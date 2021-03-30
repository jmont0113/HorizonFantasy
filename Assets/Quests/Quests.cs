using System.Collections;
using UnityEngine;

[System.Serializable]
public class Quests
{
    public enum QuestProgress { NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE}

    public string title;            //title for the quest
    public int id;                  //ID number for the Quest
    public QuestProgress progress;  //state of the current quest(enum)
    public string description;      //string from our quest Giver/Receiver
    public string hint;             //string from our quest Giver/Receiver
    public string congratulation;   //string from our quest Giver/Receiver
    public string summary;          //string from our quest Giver/Receiver
    public int nextQuest;           //the next quest - if there is any (chain quest)

    public string questObjectives;  //name of the quest objective (also for remove)
    public int questObjectiveCount; //current number of questObjective count
    public int questObjectiveRequirement;  //required amount of quest objective objects

    public int expReward;
    public int goldReward;
    public string itemReward;
}

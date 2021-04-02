using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Quest quest = new Quest();
    public GameObject questPrintBox;
    public GameObject buttonPrefab;
    public GameObject victoryPopup;

    QuestEvent final;

    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;

    void Start()
    {
        //create each event
        QuestEvent a = quest.AddQuestEvent("Find an ancient vase", "Collecting it will help you", A);
        QuestEvent b = quest.AddQuestEvent("Find and talk to Robo ", "He will need help open a door", B);
        QuestEvent c = quest.AddQuestEvent("Find and talk to Arthur", "He will give you information", C);
        QuestEvent d = quest.AddQuestEvent("Find and talk to the Bandit", "He will give you information", D);
        QuestEvent e = quest.AddQuestEvent("Find and use the lever", "Robo needs you to use it", E);

        //define the paths between the events = e.g. the order they must be completed
        quest.AddPath(a.GetId(), b.GetId());
        quest.AddPath(b.GetId(), c.GetId());
        quest.AddPath(b.GetId(), d.GetId());
        quest.AddPath(c.GetId(), e.GetId());
        quest.AddPath(d.GetId(), e.GetId());

        quest.BFS(a.GetId());

        QuestButton button = CreateButton(a).GetComponent<QuestButton>();
        A.GetComponent<QuestLocation>().Setup(this, a, button);
        button = CreateButton(b).GetComponent<QuestButton>();
        B.GetComponent<QuestLocation>().Setup(this, b, button);
        button = CreateButton(c).GetComponent<QuestButton>();
        C.GetComponent<QuestLocation>().Setup(this, c, button);
        button = CreateButton(d).GetComponent<QuestButton>();
        D.GetComponent<QuestLocation>().Setup(this, d, button);
        button = CreateButton(e).GetComponent<QuestButton>();
        E.GetComponent<QuestLocation>().Setup(this, e, button);

        final = e; 

        quest.PrintPath();
    }

    GameObject CreateButton(QuestEvent e)
    {
        GameObject b = Instantiate(buttonPrefab);
        b.GetComponent<QuestButton>().Setup(e, questPrintBox);
        if(e.order == 1)
        {
            b.GetComponent<QuestButton>().UpdateButton(QuestEvent.EventStatus.CURRENT);
            e.status = QuestEvent.EventStatus.CURRENT;
        }
        return b;
    }

    public void UpdateQuestsOnCompletion(QuestEvent e)
    {
        if(e == final)
        {
            victoryPopup.SetActive(true);
            return;
        }

        foreach(QuestEvent n in quest.questEvents)
        {
            //if this event is the next in order
            if(n.order == (e.order + 1))
            {
                //make the next in line available for completion
                n.UpdateQuestEvent(QuestEvent.EventStatus.CURRENT);
            }
        }
    }


    public void CloseVictoryPopup()
    {
        victoryPopup.SetActive(false);
    }
}

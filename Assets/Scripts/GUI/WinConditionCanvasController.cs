using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditionCanvasController : MonoBehaviour
{
    [SerializeField] List<Text> texts;
    [SerializeField] List<Value> values;

    public void Set(StatsContainer rewards)
    {
        for(int i = 0; i < values.Count; i++)
        {
            texts[i].text = rewards.GetText(values[i]);
        }
    }


    public void CloseWinConditionCanvas()
    {
        gameObject.SetActive(false);
    }
}

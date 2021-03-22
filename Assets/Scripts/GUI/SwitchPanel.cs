using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] List<GameObject> panels;

    public void OpenPanel(int number)
    {
        for(int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(number == i);
        }
    }

    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }
}

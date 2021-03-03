using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    List<GameObject> highlighters;
    [SerializeField] GameObject highlightPrefab;
    [SerializeField] GameObject highlightContainer;

    private void Start()
    {
        highlighters = new List<GameObject>();
    }

    public void Highlight(List<Vector3> pos)
    {
        /*
        add more highlighters if there is not enough of them to highlight all the received
        position
        */
        while (highlighters.Count < pos.Count)
        {
            GameObject go = Instantiate(highlightPrefab);
            highlighters.Add(go);
            go.transform.parent = highlightContainer.transform;
        }

        for (int i = 0; i < pos.Count; i++)
        {
            highlighters[i].SetActive(true);
            highlighters[i].transform.position = pos[i] + Vector3.up * 1f; 
            //we add 1 or more to vector 3 up so the marker will appear ABOVE the positiion 
        }
    }

    public void Hide()
    {
        for(int i = 0; i < highlighters.Count; i++)
        {
            highlighters[i].SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenMessage : MonoBehaviour
{
    class TextContainer
    {
        public RectTransform rectTransform;
        public float ttl;
        public Text text;

        public TextContainer(RectTransform _rectTransform, float _ttl, Text _text)
        {
            rectTransform = _rectTransform;
            ttl = _ttl;
            text = _text;
        }
    }

    [SerializeField] Transform canvas;
    [SerializeField] GameObject textPrefab;
    List<TextContainer> busy;
    List<TextContainer> free;

    private void Start()
    {
        busy = new List<TextContainer>();
        free = new List<TextContainer>();
    }

    public void ShowMessage(Vector3 worldSpacePosition, string message)
    {
        if(free.Count == 0)
        {
            GameObject go = Instantiate(textPrefab, canvas);
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.parent = canvas;

            rectTransform.position = RectTransformUtility.WorldToScreenPoint
                (Camera.main, worldSpacePosition);

            TextContainer textContainer = 
                new TextContainer(rectTransform, 5f, go.GetComponent<Text>());
            textContainer.text.text = message;
            busy.Add(textContainer);
        }
        else
        {
            free[0].text.text = message;
            free[0].ttl = 5f;
            free[0].rectTransform.position = RectTransformUtility.WorldToScreenPoint
                (Camera.main, worldSpacePosition);
            free[0].rectTransform.gameObject.SetActive(true);
            busy.Add(free[0]);
            free.RemoveAt(0);
        }
    }

    private void Update()
    {
        for(int i = 0; i < busy.Count; i++)
        {
            if(busy[i].ttl < 0 )
            {
                free.Add(busy[i]);
                busy.RemoveAt(i);
                free[i].rectTransform.gameObject.SetActive(false);
                continue;
            }
            busy[i].ttl -= Time.deltaTime;
            busy[i].rectTransform.localPosition += Vector3.up * 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyTracker : MonoBehaviour
{
    [SerializeField] Value currencyToTrack;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        text.text = GameManager.instance.currencies.Get(currencyToTrack).ToString();
    }
}

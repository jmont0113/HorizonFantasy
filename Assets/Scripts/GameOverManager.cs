using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public void GameOver()
    {
        canvas.SetActive(true);
    }
}

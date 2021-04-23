using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] AudioSource gameOver;

    public void GameOver()
    {
        gameOver.Play();
        canvas.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void MainMenu(string MainMenu)
    {
        Debug.Log("Loading Main Menu...");

        SceneManager.LoadScene(MainMenu);
    }
    public void Gameplay(string Gameplay)
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene(Gameplay);
    }
    public void ResartGame()
    {
        Debug.Log("Restart Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public GameObject pauseScreen;
    public static bool gameIsPaused;
    public GameObject rulesScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        if (DrawCards.blockPause == false)
        {
            if (gameIsPaused)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Rules()
    {
        rulesScreen.SetActive(true);
    }

    public void BackRules()
    {
        rulesScreen.SetActive(false);
    }

    public void RulesGame()
    {
        rulesScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void BackRulesGame()
    {
        rulesScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}

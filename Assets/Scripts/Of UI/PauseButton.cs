using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public void PauseButtonAction()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        if (!gameIsPaused)
        {
            Pause();
        }
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void TutorialButton()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    
}

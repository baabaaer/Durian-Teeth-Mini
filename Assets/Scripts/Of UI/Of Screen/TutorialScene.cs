using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{    
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

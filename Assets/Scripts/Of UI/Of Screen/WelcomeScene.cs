using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScene : MonoBehaviour
{
    [SerializeField] private float loadTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", loadTime);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

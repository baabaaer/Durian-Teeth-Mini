using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    public ScoreBoard scoreBoard;
    public PlayerShoot playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = playerShoot.GetComponent<PlayerShoot>();
        scoreBoard = scoreBoard.GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DurianButtonPress()
    {
        if(scoreBoard.durianTally > 0)
        {
            playerShoot.ShootTheDurian();
            scoreBoard.MinusDurian(1);
            
            
        }
        else
        {
            Debug.Log("Finish already!");
            
        }
        
    }
}

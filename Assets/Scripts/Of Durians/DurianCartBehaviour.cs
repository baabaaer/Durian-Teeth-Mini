using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DurianCartBehaviour : MonoBehaviour
{
    public ScoreBoard scoreBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        if (scoreBoard == null)
        {
            scoreBoard = FindObjectOfType<ScoreBoard>().GetComponent<ScoreBoard>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadToCart()
    {
        scoreBoard.LoadToCart();
    }
   
}

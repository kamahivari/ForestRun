using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private int playerDiamonds = 0;

    public Text uiMesafe;
    public Text uiDiamond;
    public Text scoreText;
    public Text BestScoreText;
    public static int mesafe;
    public static int score;
    public static int bestScore;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bestScore=PlayerPrefs.GetInt("bestScore",0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        mesafe = Mathf.RoundToInt(player.transform.position.z); //player'ýn z ekseni üzerindeki hareketini RoundtoInt ile en yakýn integera yuvarlayarak katedilen mesafe girilir.
        uiMesafe.text = mesafe.ToString() + " m";


      
    }

    
    public void ToplananDiamond()
    {
        playerDiamonds++;
        uiDiamond.text = playerDiamonds.ToString() + " x";  
        //Debug.Log("Coin : " + playerDiamonds);

    }
    public void SaveScore(int score)
    {
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
            
        }
        BestScoreText.text = bestScore.ToString()+" m";
        scoreText.text = mesafe.ToString()+" m";
    }
   

}

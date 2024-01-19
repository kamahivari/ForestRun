using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    public static int playerDiamonds = 0;

    public Text uiMesafe;
    public Text uiDiamond;
    public Text uiHealth;
    public Text scoreText;
    public Text BestScoreText;
    

    public static int mesafe;
    public static int score;
    public static int bestScore;

    public static int bestElmascore;
    public static int elmas;

   




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bestScore = PlayerPrefs.GetInt("bestScore", 0);//PlayerPrefs yontemiyle bestscoreyi kay�ttan al yoksa s�f�r al
        bestElmascore = PlayerPrefs.GetInt("bestElmas", 0);
        PlayerMove.healthCount = PlayerPrefs.GetInt("healthCount", 3); //Can sayisini al eger yoksa 3 can ile baslat
        if (PlayerMove.healthCount < 3)
        {
            PlayerMove.healthCount = 3;
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        mesafe = Mathf.RoundToInt(player.transform.position.z); //player'�n z ekseni �zerindeki hareketini RoundtoInt ile en yak�n integera yuvarlayarak katedilen mesafe girilir.
        uiMesafe.text = mesafe.ToString() + " m";

    }


    public void ToplananDiamond()
    {
        playerDiamonds++;
        uiDiamond.text = playerDiamonds.ToString() + " x";
        //Debug.Log("Coin : " + playerDiamonds);

    }
    public void SaveScore(int score, int elmasScore)
    {
        if (score > bestScore || elmasScore > bestElmascore)//eger kullan�c� rekorunu gectiyse yeni skor bestscore olur
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);//playerprefse set etme islemi

            bestElmascore = elmasScore;
            PlayerPrefs.SetInt("bestElmas", bestElmascore);

        }
        BestScoreText.text = bestScore.ToString() + " m  " + bestElmascore.ToString() + " E";
        scoreText.text = mesafe.ToString() + " m  " + playerDiamonds.ToString() + " E"; ; //Menuye g�ster


        
    }
    public void HealthDecrease()
    {
        PlayerMove.healthCount--; // Can'� bir azalt

        uiHealth.text = PlayerMove.healthCount.ToString() + " x"; ////NEDEN YAZIYA ULA�AMIYORUM TEXT VALUES�N� 1 B�LE YAPAMIYORUM

    }






}

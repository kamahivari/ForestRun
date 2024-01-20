using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    

    public static int playerDiamonds = 0;
    public static int HealthPrice = 5;

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
    public static int healthcount;
    public static int totalElmas;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bestScore = PlayerPrefs.GetInt("bestScore", 0);//PlayerPrefs yontemiyle bestscoreyi kayýttan al yoksa sýfýr al
        bestElmascore = PlayerPrefs.GetInt("bestElmas", 0);
        totalElmas = PlayerPrefs.GetInt("totalElmas", 0);
        healthcount = PlayerPrefs.GetInt("healthCount", 3); //Can sayisini al eger yoksa 3 can ile baslat
        uiHealth.text= PlayerPrefs.GetInt("healthCount", 3).ToString()+ " x";

        if (healthcount < 3)
        {
            healthcount = 3;
            
        }
        



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
    public void SaveScore(int score, int elmasScore)
    {
        if (score > bestScore || elmasScore > bestElmascore)//eger kullanýcý rekorunu gectiyse yeni skor bestscore olur
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);//playerprefse set etme islemi

            bestElmascore = elmasScore;
            PlayerPrefs.SetInt("bestElmas", bestElmascore);

        }
        BestScoreText.text = bestScore.ToString() + " m  " + bestElmascore.ToString() + " E";
        scoreText.text = mesafe.ToString() + " m  " + playerDiamonds.ToString() + " E"; ; //Menuye göster
        totalElmas += elmasScore;
        PlayerPrefs.SetInt("totalElmas", totalElmas);





    }
    public void HealthDecrease()
    {
        GameManager.healthcount--; // Can'ý bir azalt
        uiHealth.text = GameManager.healthcount.ToString() + " x"; ////NEDEN YAZIYA ULAÞAMIYORUM TEXT VALUESÝNÝ 1 BÝLE YAPAMIYORUM


    }
    public static void BuyHealth() {

        if (totalElmas >= HealthPrice)
        {

            if (healthcount < 3)
            {
                healthcount = 4; //Onlem amaclý
            }
            else
            {
                healthcount++; //Can arttýr
                Debug.Log("Can alýndý");
            }

            totalElmas -= HealthPrice;//Saglýk fiyatý kadar elmas azalt
            PlayerPrefs.SetInt("totalElmas", totalElmas); //Bakiyeyi kaydet
            PlayerPrefs.SetInt("healthCount", healthcount); //Alýnan cani kaydet

        }
      

    }






}

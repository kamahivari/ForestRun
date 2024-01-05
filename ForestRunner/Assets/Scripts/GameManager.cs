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



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int mesafe = Mathf.RoundToInt(player.transform.position.z); //player'ýn z ekseni üzerindeki hareketini RoundtoInt ile en yakýn integera yuvarlayarak katedilen mesafe girilir.
        uiMesafe.text = mesafe.ToString() + " m";

      
    }

    
    public void ToplananDiamond()
    {
        playerDiamonds++;
        uiDiamond.text = playerDiamonds.ToString();  
        //Debug.Log("Coin : " + playerDiamonds);

    }
   

}

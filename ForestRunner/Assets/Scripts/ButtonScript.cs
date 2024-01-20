using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
     //Can alma fiyatý
    
    public MenuController menuController;
    public Text diamondText;

    public void RestartButton()
    {
        PlayerMove.isAlive = true;
        GameManager.healthcount = 3;
        PlayerPrefs.SetInt("healthCount", 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Sahneyi yeniden baslat
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void BuyHealthButton()
    {
       
        GameManager.BuyHealth();
        diamondText.text = PlayerPrefs.GetInt("totalElmas", 0).ToString() + "x";

    }
}

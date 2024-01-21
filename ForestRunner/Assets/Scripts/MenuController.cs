using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
     public Text diamondText;
    public Text scoreText;
     int totalElmas;
    int bestScore;


    //----->> Main Menu SFX ve Music

    AudioManager_Main audioManager_main;


    private void Awake()
    {
        audioManager_main = GameObject.FindGameObjectWithTag("Audio_Main").GetComponent<AudioManager_Main>();       //audiomanager_main componentleri çek
    }
    void Start()
    {
        totalElmas = PlayerPrefs.GetInt("totalElmas", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        diamondText.text=totalElmas.ToString() + "x";
        scoreText.text=bestScore.ToString() + "m";
    }
     
    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartGame()
    {
        PlayerMove.isAlive = true;
        SceneManager.LoadScene("Level01");

        audioManager_main.PlaySFX(audioManager_main.buttonClick); //buttonclick sound
    }

    public void ExitGame()
    {
        audioManager_main.PlaySFX(audioManager_main.buttonClick); //buttonclick sound
        Application.Quit();
       // Debug.Log("Çýkýþ");
    }
   

}

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
    void Start()
    {
        int bestElmascore = PlayerPrefs.GetInt("bestElmas", 0);
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        diamondText.text=bestElmascore.ToString() + "x";
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
    }

    public void ExitGame()
    {

        Application.Quit();
       // Debug.Log("Çýkýþ");
    }
}

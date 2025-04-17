using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text score;
    private int scoreCount;
    void Start()
    {
        PlayerHealth.OnPlayedDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }
    
    public void RestartGame() {
        gameOverScreen.SetActive(false);
        scoreCount = 0;
    }
   
    void GameOverScreen() {
        gameOverScreen.SetActive(true);
    }


}

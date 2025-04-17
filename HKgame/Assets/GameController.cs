using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public static event Action OnReset;

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
        OnReset.Invoke();
    }
   
    void GameOverScreen() {
        gameOverScreen.SetActive(true);
    }


}

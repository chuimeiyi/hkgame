using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour
{
    public static event Action OnReset;

    public GameObject pauseMenu;
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
        // RestartScene();   // 重開scene
        // 想傳送到spawnpoint
    }
   
    void GameOverScreen() {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /*備用計劃
    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */

    IEnumerator test() { 
        yield return new WaitForSecondsRealtime(3);

    }

}

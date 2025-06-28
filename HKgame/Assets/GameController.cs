using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class GameController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static event Action OnReset;

    [Header("UI References")]
    public GameObject pauseMenu;
    public GameObject gameOverScreen;


    [Header("Player Settings")]
    public playerMovement[] players; // 玩家数组（在Inspector中配置）

    private int scoreCount;
    public colC itemCount;
    private static GameController _instance;

    // 单例实现
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameController");
                    _instance = go.AddComponent<GameController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        // 场景加载时自动查找玩家
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        InitializePlayers();
        PlayerHealth.OnPlayedDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }


    // 玩家锁定方法
    public void LockPlayers(bool isLocked)
    {
        if (players == null || players.Length == 0)
        {
            Debug.LogWarning("No players assigned in GameController!");
            return;
        }

        foreach (var player in players)
        {
            if (player != null)
            {
                player.lockPlayer = isLocked;
                Debug.Log($"Player {player.name} locked: {isLocked}");
            }
        }
    }

    // 场景加载回调
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializePlayers();
    }

    // 初始化玩家引用
    private void InitializePlayers()
    {
        if (players == null || players.Length == 0)
        {
            players = FindObjectsOfType<playerMovement>();
            Debug.Log($"Auto-found {players.Length} players in scene");
        }
    }

    // 原有功能保持不变
    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        scoreCount = 0;
        OnReset?.Invoke();
    }

    void GameOverScreen()
    {
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

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        PlayerHealth.OnPlayedDied -= GameOverScreen;
    }
}
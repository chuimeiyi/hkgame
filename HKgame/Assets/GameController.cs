using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static event Action OnReset;

    [Header("UI References")]
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public Text score;

    [Header("Player Settings")]
    public playerMovement[] players; // ������飨��Inspector�����ã�

    private int scoreCount;
    public colC itemCount;
    private static GameController _instance;

    // ����ʵ��
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

        // ��������ʱ�Զ��������
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        InitializePlayers();
        PlayerHealth.OnPlayedDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }
    

    // �����������
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

    // �������ػص�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializePlayers();
    }

    // ��ʼ���������
    private void InitializePlayers()
    {
        if (players == null || players.Length == 0)
        {
            players = FindObjectsOfType<playerMovement>();
            Debug.Log($"Auto-found {players.Length} players in scene");
        }
    }

    // ԭ�й��ܱ��ֲ���
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
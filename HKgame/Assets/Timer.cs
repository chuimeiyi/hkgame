using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public static Timer Instance;  // Singleton instance
    public static float myTimer = 0;  // Static to persist
    public Text timeText;  // Assign in Inspector



    void Start()
    {
        // Load saved time (if any)
        myTimer = PlayerPrefs.GetFloat("scoreData", myTimer);
        UpdateDisplay();
    }

    void Update()
    {
        myTimer += Time.deltaTime;
        UpdateDisplay();
        SaveTime();
    }

    void UpdateDisplay()
    {
        if (timeText != null)
        {
            timeText.text = myTimer.ToString("0.0's'");
        }
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("scoreData", myTimer);
        PlayerPrefs.Save();
    }

}

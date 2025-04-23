using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public static Timer Instance;  // Singleton instance
    public static float myTimer = 0;  // Static to persist
    public Text timeText;  // Assign in Inspector
    public int stageentertime;
    public int enteredtime;




    void Start()
    {
        // Load saved time (if any)
        myTimer = PlayerPrefs.GetFloat("scoreData", myTimer);
        UpdateDisplay();
        enteredtime = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            enteredtime = enteredtime + 1;
        }

            if (enteredtime >= stageentertime)
        {
            myTimer += Time.deltaTime;
            UpdateDisplay();
            SaveTime();
        }
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

    public void resetcount() {
        enteredtime = 0;
    }
}

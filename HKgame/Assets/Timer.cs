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
    public bool reset;





    void Start()
    {
        enteredtime = 0;
        if (reset == true)
        {
            Resettime();
            SaveTime();
        }
        else {
            // Load saved time (if any)
            myTimer = PlayerPrefs.GetFloat("scoreData", myTimer);
            UpdateDisplay();
        }

    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            enteredtime = enteredtime + 1;
        }

            if (enteredtime >= stageentertime){
            myTimer += Time.deltaTime;
            UpdateDisplay();
            SaveTime();
            }

    }

    void UpdateDisplay()
    {
        if (timeText != null)
        {
            timeText.text = "time:" + myTimer.ToString("0.0's'");
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

    public void Resettime()
    {
        myTimer = 0;
    }
}

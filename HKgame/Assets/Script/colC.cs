using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Flower;
using UnityEngine.SceneManagement;
using TMPro;


public class colC : MonoBehaviour
{
    [Header("Items Counting")]
    public int itemCount;
    public int tempCount;
    public Text itemcount;

    [Header("Scores")]
    public TMP_Text finishUiTotal;
    public TMP_Text gameOverUiTotal;
    public Text scoreText;

    [Header("UI References")]
    public GameObject finishscreen;

    [Header("Extra settings")]
    int total;
    int stage;
    public bool reset;


    // Start is called before the first frame update
   void Start()
    {
        if (reset == true)
        {
            Resettotal();
            Savetotal();
        }
        else
        {
            total = PlayerPrefs.GetInt("total", total);
        }
    }


    // Update is called once per frame
    void Update()
    {
        itemcount.text = "Item :" + itemCount.ToString();


        finishUiTotal.text = total.ToString();
        gameOverUiTotal.text = "score :" + total.ToString();
        if (itemCount == 10) {
         
            finishscreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (itemCount > tempCount)
        {
            total = total + 10;
            tempCount = tempCount + 1;
            Savetotal();
        }

    }
    public void Savetotal()
    {
        PlayerPrefs.SetInt("total", total);
        PlayerPrefs.Save();
    }

    public void resetitem() {
        itemCount = 0;


    }

    public void Resettotal()
    {
        total = 0;
    }


}

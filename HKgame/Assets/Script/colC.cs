using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class colC : MonoBehaviour
{
    public int itemCount;
    public int temp;
    public Text itemcount;
    public Text totaliscorecount;
    public GameObject finishscreen;
    int total;
    // Start is called before the first frame update

    void Start()
    {
        total = PlayerPrefs.GetInt("total", total);
    }

    // Update is called once per frame
    void Update()
    {
        itemcount.text = "Item :" + itemCount.ToString();

        if (itemCount > temp) {
            total = total + itemCount * 10;
            temp = temp + 1;
        }

        totaliscorecount.text = "score :" + total.ToString();
        if (itemCount == 10) {
            finishscreen.SetActive(true);
            Time.timeScale = 0;
        }
        SaveTime();

    }
    public void SaveTime()
    {
        PlayerPrefs.SetInt("total", total);
        PlayerPrefs.Save();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Flower;
using UnityEngine.SceneManagement;

public class colC : MonoBehaviour
{
    public int itemCount;
    public int temp;
    public Text itemcount;
    public Text totaliscorecount;
    public Text totalcountgo;
    public GameObject finishscreen;
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


        totaliscorecount.text = "score :" + total.ToString();
        totalcountgo.text = "score :" + total.ToString();
        if (itemCount == 10) {
         
            finishscreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (itemCount > temp)
        {
            total = total + 10;
            temp = temp + 1;
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

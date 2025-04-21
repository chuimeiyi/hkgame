using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colC : MonoBehaviour
{
    public int itemCount;
    public Text Textitemcount;
    public GameObject finishscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Textitemcount.text = "Item :" + itemCount.ToString();
        if (itemCount == 10) {
            finishscreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

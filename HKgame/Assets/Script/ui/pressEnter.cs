using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pressEnter : MonoBehaviour
{

    public KeyCode enter;
    public KeyCode stop;
    public GameObject enterpage;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(stop)|| flag==true )
        {
            Time.timeScale = 0;
            flag = true;
            
        }
        else if (Input.GetKey(enter)){
            Time.timeScale = 1;
            enterpage.SetActive(false);
        }
    }
}

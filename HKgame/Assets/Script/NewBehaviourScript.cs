using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    private Animator ani;
    private Rigidbody2D rBody;

    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取水平轴-101 
        float horizontal = Input.GetAxisRaw("Horizontal");
        //获取垂直轴 
        float vertical = Input.GetAxisRaw("Vertical");
        //按下左或右了 
        if (horizontal != 0)
        {
        
        ani.SetFloat("Horizontal", horizontal);
        ani.SetFloat("Vertical", 0);
        }
    }
}

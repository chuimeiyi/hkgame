using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count1 : MonoBehaviour
{
    public int currentHealth;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        setCount();
    }

    public void setCount()
    {
        currentHealth = GameObject.Find("player2").GetComponent<PlayerHealth>().currentHealth;
        animator.SetInteger("count", currentHealth);
    }
}

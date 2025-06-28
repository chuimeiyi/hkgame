using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class count : MonoBehaviour
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

    public void setCount() {
  
        animator.SetInteger("count", currentHealth);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayedDied;

    public int currentHealth = HealthManager.currentHealth;
    public int maxHealth = HealthManager.currentHealth;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;

    }




    void Update()
    {
        if (currentHealth != HealthManager.currentHealth)
        {
            HealthManager.maxHealth = currentHealth;
        }


    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;
        if (tag == "Damager")
        {
            TakeDamage(1);
        }
    }



    void ResetHealth()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(FlashRed());

    }

    private IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(0.2f);  
        OnPlayedDied.Invoke();              
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }




}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayedDied;

    public int maxHealth = 5;
    public int currentHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
        ResetHealth();


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
        if (currentHealth <= 0)
        {
            StartCoroutine(DelayedDeath());
        }
    }


        void ResetGame()
        {
            Debug.Log("Game Over! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

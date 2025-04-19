using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
   public int maxHealth = 5;
    private int currentHealth;

    public TextHPUI textHPUI;

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayedDied;

    void Start()
    {
        ResetHealth();

        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;
        if (tag == "Damager")
        {
            TakeDamage(1);
        }
    }

    void ResetHealth() {
        currentHealth = maxHealth;
        textHPUI.SetMaxHealths(maxHealth);
        Time.timeScale = 1;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        textHPUI.UpdateHealths(currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0) {
            OnPlayedDied.Invoke();
        }
    }

    private IEnumerator FlashRed() {
        spriteRenderer.color = Color.red;    
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

}

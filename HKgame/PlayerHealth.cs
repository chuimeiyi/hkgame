using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
   public int maxHealth = 5;
    public int currentHealth;

    public TextHPUI textHPUI;
    public playerMovement playMovement;

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayedDied;
    void Start()
    {
        currentHealth = maxHealth;

        textHPUI.SetMaxHealths(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.gameObject.tag;
        if (tag == "Damager")
        {
            TakeDamage(1);
        }
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

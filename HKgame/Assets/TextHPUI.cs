using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TextHPUI : MonoBehaviour
{
    private int health;
    private int currentHealth;
    public Text healthText;

    public void SetMaxHealths(int maxHealths) {
        health = maxHealths;
        healthText.text = "x" + health.ToString();
        healthText = GetComponent<Text>();
    }
   
    public void UpdateHealths(int currHealth) {
        currentHealth = currHealth;
        healthText.text = "x" + currentHealth.ToString();
    }

}
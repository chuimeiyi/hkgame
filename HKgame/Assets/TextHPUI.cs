using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TextHPUI : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public Text healthText;

    public void SetMaxHealths(int maxHealths) {
        health = maxHealths; 
    }
   
    public void UpdateHealths(int currHealth) {
        for(int i = 0; i < health; i++) {
            if (i == currHealth) {
                currentHealth = i;
                healthText.text = "x" + currentHealth.ToString();
            }    
        }
    }

}
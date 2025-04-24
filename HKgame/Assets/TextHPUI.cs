using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TextHPUI : MonoBehaviour
{
    public Text hpText; 
    

    public void SetMaxHealth(int maxHealth){
        hpText.text = "HP: " + maxHealth.ToString();
        
    }

    public void UpdateHealth(int currentHealth) {
        hpText.text = "HP: " + currentHealth.ToString();

    }
}
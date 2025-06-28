using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static int currentHealth = 5;
    public static int maxHealth = 5 ;

    public int health = 2;

    void Update()
    {
        sethealth();
    }

    public void sethealth() {

        currentHealth = health;
    }
    
}

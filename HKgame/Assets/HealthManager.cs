using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int health = 2;

    void Update()
    {
        sethealth();
    }

    public void sethealth() {

        currentHealth = health;
    }
    
}

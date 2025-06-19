using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class numcontrol : MonoBehaviour
{
    Animator number;


    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component
        number = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        number.SetInteger("count" , 4 );

    }

    public void SetMaxHealth(int maxHealth)
    {


    }

    public void UpdateHealth(int currentHealth)
    {


    }
}

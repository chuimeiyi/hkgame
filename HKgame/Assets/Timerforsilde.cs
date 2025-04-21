using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Timerforsilde: MonoBehaviour {

	public float myTimer=0;
	public Slider slider;
	public GameObject gameover;

	Text text;

	void Start () {
		text = GetComponent<Text>();
		slider.maxValue = myTimer;
		slider.minValue = 0;
	}

	void Update () {
		if (myTimer > 0) 
			myTimer -= Time.deltaTime;
		else
		{
			myTimer = 0;
		}
		slider.value = myTimer;
		text.text = (myTimer).ToString("00");

		if (myTimer == 0) {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
		
	}


	
}



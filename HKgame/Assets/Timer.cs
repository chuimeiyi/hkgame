using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float myTimer=0;

	Text text;

	void Start () {
		text = GetComponent<Text>();
	}

	void Update () {
		myTimer += Time.deltaTime;
		text.text = (myTimer).ToString("0.0's'");
	}
}



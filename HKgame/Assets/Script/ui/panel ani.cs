using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelani : MonoBehaviour
{
    public AnimationCurve ShowPanel;
    public AnimationCurve HidePanel;
    public float animationSpeed;
    public GameObject panel;

    IEnumerator ShowPanel(GameObject gameObject) { 
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * ShowCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
        
        }

    private void Update() { 
       if(Input.GetKey(KeyCode.Escape)) { 
            StartCoroutine(ShowPanel(panel));
        }
       else if(Input.GetKey(KeyCode.Return)) {
            StartCoroutine (HidePanel(panel));
            }


} 
    }

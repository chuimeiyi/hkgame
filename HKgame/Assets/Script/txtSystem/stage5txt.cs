using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class stage5txt : MonoBehaviour
{
    // Start is called before the first frame update

    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("nekoQAQ");
        fs.ReadTextFromResource("4to5");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            fs.Next();
        }
    }
}

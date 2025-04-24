using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class IntroSceneController : MonoBehaviour
{
    FlowerSystem fs;
    // Start is called before the first frame update
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("nekoQAQ", false); 
        fs.SetupDialog();
        fs.ReadTextFromResource("intro");
        fs.SetScreenReference(1920, 1080);
        fs.RegisterCommand("load_scene", (List<string>_params) => {
            SceneManager.LoadScene(_params[0]);
        });


        fs.RegisterCommand("lock_player", (List<string> _params) => {
            GameController.Instance.LockPlayers(true); // 锁定所有玩家
        });



        fs.RegisterCommand("unlock_player", (List<string> _params) => {
            GameController.Instance.LockPlayers(false);
        });

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            fs.Next();
        }
    }
}




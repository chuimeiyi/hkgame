using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class SwitchScene : MonoBehaviour {

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public string sceneName; // Assign the scene name in the Inspector

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
        Destroy(gameObject);
    }
}



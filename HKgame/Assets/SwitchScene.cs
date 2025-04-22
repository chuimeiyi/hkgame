using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class SwitchScene : MonoBehaviour {

    void Start()
    {
    }
    public string sceneName; // Assign the scene name in the Inspector

    private void Update()
    {
    }
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);

    }
}



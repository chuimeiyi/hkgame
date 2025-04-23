using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class SwitchScene : MonoBehaviour {

    public string sceneName;
    public string sceneName2;

    void Start()
    {
    }

    private void Update()
    {
    }
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);

    }

    public void reLoadTargetScene()
    {
        SceneManager.LoadScene(sceneName2);

    }


}



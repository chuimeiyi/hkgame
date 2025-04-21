using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gogobutton : MonoBehaviour
{
    public string sceneName;
    public void GoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

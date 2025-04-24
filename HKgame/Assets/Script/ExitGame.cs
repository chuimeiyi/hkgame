using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame method called");
        Application.Quit();
    }
}
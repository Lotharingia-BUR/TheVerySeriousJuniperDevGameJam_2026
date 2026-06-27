using UnityEngine;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    public Button quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quitButton.onClick.AddListener(quitAction);
    }

    void quitAction()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Credits_Toggle : MonoBehaviour
{
    public Button creditsButton;
    public Image creditsPage;
    private bool isOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditsButton.onClick.AddListener(toggleCredits);
        isOn = true;
    }

    void toggleCredits()
    {
        if (!isOn)
        {
            creditsPage.GetComponent<Image>().color = Color.clear;
            isOn = true;
        }
        else if (isOn)
        {
            creditsPage.GetComponent<Image>().color = Color.white;
            isOn = false;
        }
    }
}

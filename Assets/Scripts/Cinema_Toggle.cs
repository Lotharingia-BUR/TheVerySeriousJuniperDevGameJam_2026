using UnityEngine;
using UnityEngine.UI;

public class Cinema_Toggle : MonoBehaviour
{
    public Button cinemaButton;
    public bool isOn;
    public Sprite cbON;
    public Sprite cbOFF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        cinemaButton.onClick.AddListener(toggleCinema);
        isOn = false;
    }

    void toggleCinema()
    {
        if (!isOn)
        {
            cinemaButton.GetComponent<Image>().sprite = cbON;
            isOn = true;
        } else if (isOn)
        {
            cinemaButton.GetComponent<Image>().sprite = cbOFF;
            isOn = false;
        }
        
    }
}

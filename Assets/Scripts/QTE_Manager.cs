using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    string currentKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentKey = "-";
    }

    // Update is called once per frame
    void Update()
    {
        currentKey = checkKey();
        print(currentKey);
    }

    string checkKey()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            return "A";
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            return "D";
        } else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            return "W";
        } else if ( Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            return "S";
        } else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            return "E";
        }
        return "-";
    }
}

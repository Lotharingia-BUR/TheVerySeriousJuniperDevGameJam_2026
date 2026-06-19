using System.Collections.Generic;
using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    public string currentKey;

    //we doing csv in a list cause I can...
    //time to spawn
    //position x
    //position y
    //input
    //duration

    //if its a mash then have anonther ,
    //strength of mash

    [Tooltip("TTS,X,Y,Input,")]
    public List<string> keys;

    void Start()
    {
        currentKey = "-";
    }

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

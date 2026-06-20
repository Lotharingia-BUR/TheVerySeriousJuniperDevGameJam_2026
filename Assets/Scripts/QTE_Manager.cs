using System;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    //can be displayed in text
    public string currentKey;
    public float time;

    private int spawnIndex;

    //we doing csv in a list cause I can...
    //time to spawn
    //position x
    //position y
    //input
    //duration

    //if its a mash then have anonther ,
    //strength of mash

    [Tooltip("TTS,X,Y,Input,Duration")]
    public List<string> QTEList;
    public string[] spawnData;

    //when to spawn next qte
    private float targetTime;

    void Start()
    {
        time = 0f;
        spawnIndex = 0;
        currentKey = "-";
        spawnData = QTEData(spawnIndex);

    }

    void Update()
    { 
        currentKey = checkKey();
        if (float.TryParse(spawnData[0], out targetTime)) 
        {
            if (time > targetTime)
            {
                print("Trigger");
                spawnIndex += 1;
                spawnData = QTEData(spawnIndex);
            }
        }



        time += Time.deltaTime;
    }


    string[] QTEData(int index)
    {
        return QTEList[spawnIndex].Split(char.Parse(","));
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

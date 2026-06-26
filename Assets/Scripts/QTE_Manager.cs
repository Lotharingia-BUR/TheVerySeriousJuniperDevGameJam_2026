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
    public GameObject QTEObject;
    public GameObject QTEMashObject;
    public Animator deathAnimator;
    public AudioSource bgMusic;

    private float spawnX;
    private float spawnY;

    private GameObject spawnedObj;
    private float spawnDuration;
    private float spawnStrength;

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
        if (float.TryParse(spawnData[0], out targetTime) && spawnIndex < QTEList.Count) 
        {
            if (float.TryParse(spawnData[1], out spawnX) 
                && float.TryParse(spawnData[2], out spawnY) 
                && float.TryParse(spawnData[4], out spawnDuration))
            {

            }
            if (time > targetTime)
            {
                //Spawn QTE
                print("Trigger " + targetTime);
                if(spawnData.Length <= 5)
                {
                    spawnedObj = Instantiate(QTEObject, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
                    spawnedObj.GetComponent<Quick_Time_Event>().type = spawnData[3];
                    spawnedObj.GetComponent<Quick_Time_Event>().timeToDeath = spawnDuration;
                    spawnedObj.GetComponent<Quick_Time_Event>().orginObj = gameObject;

                } else
                {
                    
                    spawnedObj = Instantiate(QTEMashObject, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
                    spawnedObj.GetComponent<Quick_Mash_Event>().type = spawnData[3];
                    spawnedObj.GetComponent<Quick_Mash_Event>().timeToDeath = spawnDuration;
                    spawnedObj.GetComponent<Quick_Mash_Event>().orginObj = gameObject;
                    if (float.TryParse(spawnData[5], out spawnStrength))
                    {
                        spawnedObj.GetComponent<Quick_Mash_Event>().strength = spawnStrength;
                    }
                    
                }
                
                //Move up trigger
                spawnIndex += 1;
                if (spawnIndex < QTEList.Count)
                {
                    spawnData = QTEData(spawnIndex);
                }
            }
        }

        if (GameObject.Find("Cinema").GetComponent<Cinema_Toggle>().isOn == false)
        {
            // time doesent exist in cinema
            time += Time.deltaTime;
        }
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

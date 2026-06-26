using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quick_Mash_Event : MonoBehaviour
{
    [Header("Inhertied Data")]
    public string type;
    public float timeToDeath;
    public float strength;
    public GameObject orginObj;

    [Header("QTE Sprites")]
    public Sprite typeA;
    public Sprite typeD;
    public Sprite typeW;
    public Sprite typeS;
    public Sprite typeE;

    [Header("Animation")]
    public GameObject outerRing;
    public GameObject innerRing;
    public Animator qteController;

    private bool isFail;
    private float time;
    private bool isLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == "A")
        {
            GetComponent<SpriteRenderer>().sprite = typeA;
        }
        else if (type == "D")
        {
            GetComponent<SpriteRenderer>().sprite = typeD;
        }
        else if (type == "W")
        {
            GetComponent<SpriteRenderer>().sprite = typeW; ;
        }
        else if (type == "S")
        {
            GetComponent<SpriteRenderer>().sprite = typeS;
        }
        else if (type == "E")
        {
            GetComponent<SpriteRenderer>().sprite = typeE;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if current key matches type
        if (type == orginObj.GetComponent<QTE_Manager>().currentKey)
        {
            outerRing.transform.localScale += Vector3.one * strength;
        }
        if (outerRing.transform.localScale.x > innerRing.transform.localScale.x)
        {
            victory();
        }

            //Expire if time past
        if (timeToDeath < time)
        {
            failure();
        }

        // Code Animations
        if (outerRing.transform.localScale.x > 2)
        {
            outerRing.transform.localScale -= Vector3.one * (Time.deltaTime);
        } 

        if (outerRing.transform.localScale.x > innerRing.transform.localScale.x)
        {
            outerRing.transform.localScale = new Vector3 (innerRing.transform.localScale.x,  innerRing.transform.localScale.y, innerRing.transform.localScale.z);
        }

        if (isFail)
        {
            orginObj.GetComponent<QTE_Manager>().time = 0;
            orginObj.GetComponent<QTE_Manager>().bgMusic.volume -= Time.deltaTime / 2;
            timeToDeath += Time.deltaTime;
            if (timeToDeath > 1f)
            {
                //KILL HAM D:
                SceneManager.LoadScene(2);
            }
        }

        innerRing.transform.Rotate(new Vector3 (0f,0f,1f) *  (150 * (outerRing.transform.localScale.x - 1.9f)) * Time.deltaTime );
        time += Time.deltaTime; 
    }

    void victory()
    {
        if (!isFail)
        {
            isLocked = true;
            print("!Hit!");
            qteController.SetInteger("isWin", 1);
            Destroy(gameObject, .5f);
        }
    }

    void failure()
    {
        if (!isLocked)
        {
            print("!fail!");
            orginObj.GetComponent<QTE_Manager>().deathAnimator.SetBool("isDead", true);
            isLocked = true;
            isFail = true;
            qteController.SetInteger("isWin", -1);
            timeToDeath = 0;
            Destroy(gameObject, 1.2f);
        }
    }
}

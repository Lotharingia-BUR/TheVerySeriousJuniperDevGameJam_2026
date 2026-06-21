using Unity.VisualScripting;
using UnityEngine;

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

    private float time;
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
            outerRing.transform.localScale += Vector3.one * 1;
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
        if (outerRing.transform.localScale.x > 3.5)
        {
            outerRing.transform.localScale -= Vector3.one * (Time.deltaTime * strength);
        }
        
        outerRing.transform.Rotate(new Vector3 (0f,0f,1f) *  (100 * Time.deltaTime));
        time += Time.deltaTime; 
    }

    void victory()
    {
        print("!Hit!");
        qteController.SetInteger("isWin", 1);
        Destroy(gameObject, .5f);
    }

    void failure()
    {
        print("!fail!");
        qteController.SetInteger("isWin", -1);
        Destroy(gameObject, .5f);
    }
}

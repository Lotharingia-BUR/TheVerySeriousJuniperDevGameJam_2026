using UnityEngine;

public class Quick_Time_Event : MonoBehaviour
{
    [Header("Inhertied Data")]
    public string type;
    public float timeToDeath;
    public GameObject orginObj;

    [Header("QTE Sprites")]
    public Sprite typeA;
    public Sprite typeD;
    public Sprite typeW;
    public Sprite typeS;
    public Sprite typeE;

    public GameObject outerRing;
    public GameObject innerRing;

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
            print("!Hit!");
            Destroy(gameObject);
        } else if (type != orginObj.GetComponent<QTE_Manager>().currentKey && orginObj.GetComponent<QTE_Manager>().currentKey != "-")
        {
            failure();
        }

        //Expire if time past
        if(timeToDeath < time)
        {
            failure();
        }
        outerRing.transform.localScale -= Vector3.one * (Time.deltaTime * 4);
        outerRing.transform.Rotate(new Vector3 (0f,0f,1f) *  (100 * Time.deltaTime));
        time += Time.deltaTime; 

        //Change colour
        if (outerRing.transform.localScale.x < innerRing.transform.localScale.x)
        {
            outerRing.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void failure()
    {
        print("!fail!");
        Destroy(gameObject);
    }
}

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
    public Animator qteController;

    private bool isSuccess;

    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSuccess = false;
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
        if (type == orginObj.GetComponent<QTE_Manager>().currentKey && isSuccess)
        {
            victory();
        } else if (type != orginObj.GetComponent<QTE_Manager>().currentKey && orginObj.GetComponent<QTE_Manager>().currentKey != "-"
                || orginObj.GetComponent<QTE_Manager>().currentKey != "-" && !isSuccess)
        {
            failure();
        }

        //Expire if time past
        if(timeToDeath < time)
        {
            failure();
        }

        // Code Animations
        outerRing.transform.localScale -= Vector3.one * (Time.deltaTime * 4);
        outerRing.transform.Rotate(new Vector3 (0f,0f,1f) *  (100 * Time.deltaTime));
        time += Time.deltaTime; 

        //Change colour
        if (outerRing.transform.localScale.x < innerRing.transform.localScale.x)
        {
            outerRing.GetComponent<SpriteRenderer>().color = Color.green;
            isSuccess = true;
        }
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

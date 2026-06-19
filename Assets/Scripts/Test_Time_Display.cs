using UnityEngine;
using TMPro;

public class Test_Time_Display : MonoBehaviour
{
    public GameObject QTE_Obj;
    public string displayText;
    public TMP_Text textbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText != QTE_Obj.GetComponent<QTE_Manager>().time.ToString() && QTE_Obj.GetComponent<QTE_Manager>().time.ToString().Length > 4)
        {
            displayText = QTE_Obj.GetComponent<QTE_Manager>().time.ToString().Substring(0,5);
        }
        textbox.text = displayText;
    }
}

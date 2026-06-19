using UnityEngine;
using TMPro;

public class Test_QTE_Display : MonoBehaviour
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
        if (displayText != QTE_Obj.GetComponent<QTE_Manager>().currentKey && QTE_Obj.GetComponent<QTE_Manager>().currentKey != "-")
        {
            displayText = QTE_Obj.GetComponent<QTE_Manager>().currentKey;
        }
        textbox.text = displayText;
    }
}

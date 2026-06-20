using UnityEngine;

public class Quick_Time_Event : MonoBehaviour
{
    public string type;
    public float timeToDeath;

    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDeath < time)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime; 
    }
}

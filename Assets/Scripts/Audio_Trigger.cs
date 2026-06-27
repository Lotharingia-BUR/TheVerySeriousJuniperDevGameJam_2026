using UnityEngine;

public class Audio_Trigger : MonoBehaviour
{
    public bool isTriggred;
    private bool isOnce;
    public AudioSource audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isTriggred && !isOnce)
        {
            audioClip.Play();
            isOnce = true;
        } 
    }
}

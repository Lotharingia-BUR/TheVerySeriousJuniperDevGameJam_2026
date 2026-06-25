using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public float time;
    public Button sceneButton;
    public Animator sceneAnimator;
    public int sceneIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

    }
}

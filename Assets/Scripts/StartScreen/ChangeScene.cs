using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public float time;
    public Button sceneButton;
    public Animator sceneAnimator;
    public Animator UIAnimator;
    public int sceneIndex;
    private bool isSceneChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneButton.onClick.AddListener(SceneChange);
        isSceneChange = false;
    }

    void SceneChange()
    {
        sceneAnimator.SetBool("isStart", true);
        UIAnimator.SetBool("isStart", true);
        isSceneChange = true;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 11.1f && isSceneChange)
        {
            SceneManager.LoadScene(sceneIndex);
        }

    }
}

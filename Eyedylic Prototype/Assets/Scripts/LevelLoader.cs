
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            FadeToNextScene();
        }*/

    }
    public void FadeToNextScene()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete(int buildIndex)
    {
        SceneManager.LoadScene(levelToLoad);
    }

}

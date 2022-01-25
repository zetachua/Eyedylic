using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StorySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SceneTimeManager());
    }

    // Update is called once per frame
    void Update()
    {
    }

/*    IEnumerator SceneTimeManager()
    {
        for (int i = 0; i < myList.Count - 1; i++)
        {
            yield return new WaitForSeconds(myList[i].time);
            Debug.Log("durationList" + myList[i].time);
            myList[i].canvasGroup.DOFade(0, 3);
            myList[i].gameObject.SetActive(false);
            myList[i].gameObject.SetActive(true);
        }

    }*/
}

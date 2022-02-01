using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FadeinFadeout : MonoBehaviour
{
    private Tween fadeTween;
    InternalSceneManager sM;

    void Start()
    {
        sM = GetComponent<InternalSceneManager>();
        StartCoroutine(TestFade());
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            sM.ToiletSceneList[0].DialogueCanvas.interactable = true;
            sM.ToiletSceneList[0].DialogueCanvas.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            sM.ToiletSceneList[0].DialogueCanvas.interactable = false;
            sM.ToiletSceneList[0].DialogueCanvas.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = sM.ToiletSceneList[0].DialogueCanvas.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(2f);
        FadeOut(1f);
        yield return new WaitForSeconds(3f);
        FadeIn(1f);
    }
}

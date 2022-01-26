using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FadeinFadeout : MonoBehaviour
{
    private Tween fadeTween;
    DialogueManager dM;

    void Start()
    {
        dM = GetComponent<DialogueManager>();
        StartCoroutine(TestFade());
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            dM.dialogueList[0].DialogueCanvas.interactable = true;
            dM.dialogueList[0].DialogueCanvas.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            dM.dialogueList[0].DialogueCanvas.interactable = false;
            dM.dialogueList[0].DialogueCanvas.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = dM.dialogueList[0].DialogueCanvas.DOFade(endValue, duration);
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

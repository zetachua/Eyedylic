using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public CanvasGroup Canvas;
    public AudioSource DialogueAudio;
    public bool EndDialogueAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        EndDialogueAudio = false;
        StartCoroutine(PlayDialogueAudio());
    }

    IEnumerator PlayDialogueAudio()
    {
        yield return new WaitUntil(() => Canvas.alpha == 1);
        DialogueAudio.Play();
        yield return new WaitUntil(() => !DialogueAudio.isPlaying);
    }
}

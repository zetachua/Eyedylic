using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalSceneManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneReferences
    {
        public CanvasGroup DialogueCanvas;
        public GameObject TargetAudio;
        public AudioSource DialogueAudio;
        public GameObject TargetObject;
        public GameObject Highlight;
    }
    [SerializeField]
    public List<SceneReferences> ToiletSceneList = new List<SceneReferences>();

    Outline outline;
    bool playTargetAudio = false;

    void Start()
    {
        StartCoroutine(SceneManager());
    }

    IEnumerator SceneManager()
    {
        int InternalSceneNumber;
        for (InternalSceneNumber = 0; InternalSceneNumber < 3; InternalSceneNumber++)
        {
            switch (InternalSceneNumber)
            {
                case 0:
                    SetCanvasGroupActive(InternalSceneNumber);
                    yield return new WaitForSeconds(5);
                    PlayTargetAudio(InternalSceneNumber);
                    yield return new WaitForSeconds(5);
                    Highlight(InternalSceneNumber);
                    yield return new WaitUntil(() => !ToiletSceneList[InternalSceneNumber].TargetAudio.activeSelf);
                    RemoveHighlight(InternalSceneNumber);
                    break;

                case 1:
                    SetCanvasGroupActive(InternalSceneNumber);
                    yield return new WaitForSeconds(8);
                    break;

                case 2:
                    SetCanvasGroupActive(InternalSceneNumber);
                    yield return new WaitForSeconds(8);
                    break;
            }
            SetCanvasGroupInactive(InternalSceneNumber);
        }
    }

    //Set Canvas Active and Handle the Sound
    public void SetCanvasGroupActive(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha = 1;
        playTargetAudio = true;
    }

    //Set Canvas Inactive
    public void SetCanvasGroupInactive(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha = 0;
    }

    //Play TargetAudio
    public void PlayTargetAudio(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].TargetAudio.SetActive(true);
        playTargetAudio = false;
    }

    //On highlight if more than 5 seconds
    public void Highlight(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].Highlight.SetActive(true);
    }

    //Set Highlight Inactive once object is found (box collider triggered, set targetaudio to inactive)
    public void RemoveHighlight(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].Highlight.SetActive(false);
    }

    /*    public void Highlight(int InternalSceneNumber)
        {
            outline = ToiletSceneList[InternalSceneNumber].TargetObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
            outline.enabled = true;
        }*/

    /*    public void RemoveHighlight()
        {
            Destroy(outline);
            endScene = true;
        }*/
}

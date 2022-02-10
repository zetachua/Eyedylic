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
    GameObject dialoguePrefab;
    string systemVoice="You have a notification: Project discussion on zoom meeting at 12.00pm, starting in 5 minutes.";

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
                    RemoveHighlight();
                    break;

                case 1:
                    ShowDialogue(systemVoice, 0, InternalSceneNumber);
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

    public void Highlight(int InternalSceneNumber)
    {
        outline = ToiletSceneList[InternalSceneNumber].TargetObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
        outline.enabled = true;
    }

    public void RemoveHighlight()
    {
        Destroy(outline);
    }

    IEnumerator ShowDialogue(string Text, float ExitDelay, int InternalSceneNumber)
    {
        PopupDialogue dialogueBox = Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PopupDialogue>();
        dialogueBox.text = Text;
        dialogueBox.exitDelay = ExitDelay;
        yield return new WaitUntil(() => ToiletSceneList[InternalSceneNumber].DialogueAudio.isPlaying == false);
        dialogueBox.delete();
    }
}

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
    public GameObject dialoguePrefab;
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
                    StartCoroutine(ShowDialogue(systemVoice, 0, InternalSceneNumber));
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
    //Takes in the text and exit delay as parameter. The internalscenenumber is optional and I'm not sure what you're going to use it for
    IEnumerator ShowDialogue(string Text, float ExitDelay, int InternalSceneNumber)
    {
        PopupDialogue dialogueBox = Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PopupDialogue>();//instantiates the dialogue prefab
        dialogueBox.text = Text; //Sets the text of the dialogue popup
        dialogueBox.exitDelay = ExitDelay; //Optional parameter to delay the exit time, just set to 0 if unused
        dialogueBox.StartDialogue(); //Shows the text after the settings are set
        //yield return new WaitUntil(() => ToiletSceneList[InternalSceneNumber].DialogueAudio.isPlaying == false); 
        yield return new WaitForSeconds(10); //Not sure what you want it to wait for, but just add in the delay here
        dialogueBox.delete(); //Deletes the popup after waiting
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InternalSceneManager : MonoBehaviour
{
    public GameObject CameraXR;

    public GameObject dialoguePrefab;
    public int currentMenuIndex = 0;
    private GameObject TargetObject;
    Outline outline;

    [System.Serializable]
    public struct SceneReferences
    {
        public CanvasGroup DialogueCanvas;
        public AudioSource TargetAudio;
        public AudioSource DialogueAudio;
        public GameObject TargetObject;
        public string DialogueText;
    }

    [SerializeField]
    public List<SceneReferences> ToiletSceneList = new List<SceneReferences>();

    void Start()
    {
        
        

        Debug.Log("Hi");
        for (int InternalSceneNumber = 0; InternalSceneNumber < 3; InternalSceneNumber++)
        {
            StartCoroutine(SetActiveMenu(InternalSceneNumber));
            //After SetActiveMenu finishes each internal scene, Set InActive the current Canvas 
            ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha=0;
        }

    }

    IEnumerator SetActiveMenu(int InternalSceneNumber)
    {
        Debug.Log("Bye");
        //Set Canvas Active and Handle the Sound, Highlight, Target
        ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha=1;
        yield return new WaitForSeconds(3);

        DialogueAudioHandler(InternalSceneNumber);
        TargetAudioHandler(InternalSceneNumber);
        HighlightHandler(InternalSceneNumber);
    }

    //Dialogue Audio Play
    public void DialogueAudioHandler(int InternalSceneNumber)
    {
        if (ToiletSceneList[InternalSceneNumber].DialogueAudio != null){
            ToiletSceneList[InternalSceneNumber].DialogueAudio.Play(0);
            ShowDialogue(ToiletSceneList[InternalSceneNumber].DialogueText, 3);
        }
    }

    //Target Object is set active, Start Target Audio
    //If Target Object is Collided, Stop Target Audio, Set Inactive Target Button,  Set Inactive Highlight on Target Object (SCRIPT)
    public void TargetAudioHandler(int InternalSceneNumber)
    {
        if (ToiletSceneList[InternalSceneNumber].TargetObject != null && ToiletSceneList[InternalSceneNumber].TargetAudio != null){
            ToiletSceneList[InternalSceneNumber].TargetAudio.Play(0);
            ToiletSceneList[InternalSceneNumber].TargetAudio.loop=true;
            //wait for TargetTrigger() event trigger
        }
    }
    
    IEnumerator HighlightHandler(int InternalSceneNumber)
    {
        //Highlight Target Object Set Active if >10 seconds and targetAudio is still playing
        yield return new WaitForSeconds(10);
        if (ToiletSceneList[InternalSceneNumber].TargetAudio.isPlaying)
        {
            Highlight(InternalSceneNumber);
        }
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

    public void ShowDialogue(string Text, float ExitDelay)
    {
        PopupDialogue dialogueBox = Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PopupDialogue>();
        dialogueBox.text = Text;
        dialogueBox.exitDelay = ExitDelay;

    }

}

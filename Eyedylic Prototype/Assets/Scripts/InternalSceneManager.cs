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
       StartCoroutine(SetActiveMenu());           
    }

    IEnumerator SetActiveMenu()
    {
        Debug.Log("Start");

        for (int InternalSceneNumber = 0; InternalSceneNumber < 3; InternalSceneNumber++)
        {
            //Set Canvas Active and Handle the Sound, Highlight, Target
            ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha=1;
            yield return new WaitForSeconds(3);
            Debug.Log("3 seconds passsed");

            DialogueAudioHandler(InternalSceneNumber);

            yield return new WaitUntil(() => ToiletSceneList[InternalSceneNumber].DialogueAudio.isPlaying == false);
            Debug.Log("DoneWaiting");
            TargetAudioHandler(InternalSceneNumber);
            Debug.Log("TargetAudioPlaying");
            HighlightHandler(InternalSceneNumber);

            //After SetActiveMenu finishes each internal scene, Set InActive the current Canvas 
            ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha = 0;
        }

    }

    //Dialogue Audio Play
    public void DialogueAudioHandler(int InternalSceneNumber)
    {
        ToiletSceneList[InternalSceneNumber].DialogueAudio.Play();
        Debug.Log("Dialougue Audio Playing");
        //ShowDialogue(ToiletSceneList[InternalSceneNumber].DialogueText, 3);

    }

    //Target Object is set active, Start Target Audio
    //If Target Object is Collided, Stop Target Audio, Set Inactive Target Button,  Set Inactive Highlight on Target Object (SCRIPT)
    public void TargetAudioHandler(int InternalSceneNumber)
    {
        if(ToiletSceneList[InternalSceneNumber].TargetAudio != null)
        {
            ToiletSceneList[InternalSceneNumber].TargetAudio.Play();
            ToiletSceneList[InternalSceneNumber].TargetAudio.loop = true;
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

    IEnumerator HighlightHandler(int InternalSceneNumber)
    {
        if (ToiletSceneList[InternalSceneNumber].TargetAudio != null)
        {
            //Highlight Target Object Set Active if >10 seconds and targetAudio is still playing
            yield return new WaitForSeconds(10);
            Highlight(InternalSceneNumber);

            yield return new WaitUntil(() => ToiletSceneList[InternalSceneNumber].TargetAudio.isPlaying == false);
            RemoveHighlight();
        }
    }

    public void ShowDialogue(string Text, float ExitDelay)
    {
        PopupDialogue dialogueBox = Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PopupDialogue>();
        dialogueBox.text = Text;
        dialogueBox.exitDelay = ExitDelay;

    }

}

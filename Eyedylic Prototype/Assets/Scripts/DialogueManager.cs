using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject CameraXR;

    public GameObject HighlightTarget;

    Outline outline;
    public Button TargetButton;
    public int currentMenuIndex = 0;
    int count = 10;

    

    [System.Serializable]
    public struct DialogueReferences
    {
        public CanvasGroup DialogueCanvas;
        public AudioSource TargetAudio;
        public AudioSource DialogueAudio;
        public GameObject Highlight;

    }
    [SerializeField]
    public List<DialogueReferences> dialogueList = new List<DialogueReferences>();


    

    //LevelLoader()
    //control audio difficulty, filter difficulty

    //StartSceneLoader()
    //if condition: when select all required story details in start Canvas, then setActive transitionScene button 

    //FadeoutFadeIn()
    //eventlistener: when press transitionScene button, then fadeout 3 sec then fadein 3 sec + cameraPOS in env + SetActiveMenu() + ResetMenu() 

    //setActiveMenu(X)
    //set active canvas X  + soundHandler(dialogueAudioX) + highlightHandler(highlightX)\
    //if condition: last canvas element in list and !dialogueAudio.activeSelf, then setActive transitionScene button 
    //if !dialogueAudioX.activeSelf, targetButton remains inactive
    //ResetMenu()
    //set all menus,audios,highlights to inactive

    //soundHandler(dialogueAudioX)
    //set dialogueAudioX to playonawake and setactive(true), after dialogueAudio.Length counter ==0, setActive(false) 
    //(if condition: canvasGroup has targetSound component) after 3 seconds then check targetSound to playonawake and setactive(true)

    //stoptargetSound() 
    //eventlistener: when phone button pressed/grabbed then uncheck targetsound playonawake and setActive(false) + setActiveMenu(X+1) + highlight setActive(false)

    //HighlightHandler(highlightX)
    //<call function on update> if condition: targetSound.activeSelf >10 seconds, then setActive(true) highlight handler and arrow

    void Start()
    {
        //StartCoroutine(SetActiveMenu());
    }

    /*    
        IEnumerator SetActiveMenu(int X)
        {
           dialogueList[X].DialogueCanvas.Alpha(1);
            yield new return WaitForSeconds(3);
            dialogueList[X].DialogueAudio.PlayOnAwake(true);
            yield new return WaitForSeconds(3);
            dialogueList[X].DialogueAudio.PlayOnAwake(false);

            //TargetButton.SetActive(true);
            dialogueList[X].TargetAudio.PlayOnAwake(true);
            while(count>0){
              //count-=1*Time.Delta;
              dialogueList[X].Highlight.SetActive(true);
            }




        } 
    
        public void ResetMenu()
        {
            //Dialogue Canvases
            for (int i = 0; i < dialogueList.Count; i++)
            {
                dialogueList[i].DialogueCanvas.SetActive(false);
                dialogueList[i].DialougeAudio1.playOnAwake = false;
                dialogueList[i].DialougeAudio2.playOnAwake = false;
                dialogueList[i].Highlight.SetActive(false);
            }
        }

    public void StopPlaying()
    {
        TargetButton.
        //reference to audio prefab

        dialogueList[i].DialogueCanvas.SetActive(false);
        dialogueList[i+1].DialogueCanvas.SetActive(true);

    }

    */

    public void Highlight()
    {
        outline = HighlightTarget.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
        outline.enabled = true;
    }

    public void RemoveHighlight()
    {
        Destroy(outline);
    }


    


}

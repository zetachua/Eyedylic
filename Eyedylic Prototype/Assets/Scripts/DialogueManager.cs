using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour
{
    public GameObject CameraXR;
    public int currentMenuIndex = 0;

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

    //ResetMenu()
    //set all menus,audios,highlights to inactive

    //soundHandler(dialogueAudioX)
    //set dialogueAudioX to playonawake and setactive(true), after dialogueAudio.Length counter ==0, setActive(false) 
    //(if condition: canvasGroup has targetSound component) after 3 seconds then check targetSound to playonawake and setactive(true)

    //stoptargetSound() 
    //eventlistener: when phone button pressed/grabbed then uncheck targetsound playonawake and setActive(false) + setActiveMenu(X+1) + highlight setActive(false)

    //HighlightHandler(highlightX)
    //<call function on update> if condition: targetSound.activeSelf >10 seconds, then setActive(true) highlight handler and arrow


    /*    
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
    */


}

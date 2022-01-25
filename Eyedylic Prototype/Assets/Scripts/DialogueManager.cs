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
    List<DialogueReferences> dialogueList = new List<DialogueReferences>();

    //LevelLoader()
    //int LevelIndex;
    //audio difficulty, filter difficulty

    //StartSceneLoader()
    //if condition: when select all required story details in start Canvas, then setActive transitionScene button 
    //if condition: last canvas element in list and !dialogueAudio.activeSelf, then setActive transitionScene button 

    //FadeoutFadeIn()
    //eventlistener: when press transitionScene button, then fadeout 3 sec then fadein 3 sec + cameraPOS in env + SetActiveMenu() + ResetMenu() 

    //setActiveMenu(X)
    //set active canvas X  + soundHandler(dialogueAudioX) + highlightHandler(highlightX)

    //ResetMenu()
    //set all menus,audios,highlights to inactive

    //switchmenu()
    //fadeout + set inactive canvas x

    //soundHandler(dialogueAudioX)
    //set dialogueAudioX to playonawake and setactive(true), after dialogueAudio.Length counter ==0, setActive(false) 
    //(if condition: canvasGroup has targetSound component) after 3 seconds then check targetSound to playonawake and setactive(true)

    //stoptargetSound() 
    //eventlistener: when phone button pressed/grabbed then uncheck targetsound playonawake and setActive(false) + setActiveMenu(X+1) + highlight setActive(false)

    //HighlightHandler(highlightX)
    //<call function on update> if condition: targetSound.activeSelf >10 seconds, then setActive(true) highlight handler and arrow



    public void SwitchMenu(int index)
    {
        //when object is found, switch menu
        if (index >= dialogueList.Count) return;
        //StartCoroutine(FadeOut(currentMenuIndex));
    }

/*    IEnumerator FadeOut(int currentMenuIndex)
    {
        // fade out current menu, fade in next menu
        for (int i = 0; i < dialogueList.Count; i++)
        {
            dialogueList[currentMenuIndex].canvasGroup.DOFade(0, 3);
            dialogueList[currentMenuIndex + 1].canvasGroup.DOFade(0, 3);
        }
    }*/

    /*    IEnumerator DialogueSelector(int DialogueNumber)
        {

            *DialogueNumber = 1;
            *        switch (DialogueNumber)
            {
                case 0:
                    yield return new WaitForSeconds(5);
                    dialogueList[0].DialogueCanvas.SetActive(true);
                    dialogueList[0].Highlight.SetActive(true);
                    dialogueList[0].DialougeAudio1.playOnAwake = true;
                    yield return new WaitForSeconds(2);
                    dialogueList[0].DialougeAudio2.playOnAwake = true;
                    break;

                case 1:
                    yield return new WaitForSeconds(5);
                    dialogueList[1].DialogueCanvas.SetActive(true);
                    dialogueList[1].DialougeAudio1.playOnAwake = true;
                    dialogueList[1].Highlight.SetActive(true);
                    break;

                case 2:
                    yield return new WaitForSeconds(5);
                    dialogueList[2].DialogueCanvas.SetActive(true);
                    dialogueList[2].DialougeAudio1.playOnAwake = true;
                    dialogueList[2].Highlight.SetActive(true);
                    break;
            }

            //Reset();
        }*/

    /* public void Reset()
     {
         //Dialogue Canvases
         for (int i = 0; i < dialogueList.Count; i++)
         {
             dialogueList[i].DialogueCanvas.SetActive(false);
             dialogueList[i].DialougeAudio1.playOnAwake = false;
             dialogueList[i].DialougeAudio2.playOnAwake = false;
             dialogueList[i].Highlight.SetActive(false);
         }
     }*/
}

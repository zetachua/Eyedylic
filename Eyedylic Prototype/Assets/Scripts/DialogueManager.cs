using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour
{
    public GameObject CameraXR;

    [System.Serializable]
    public struct DialogueReferences
    {
        public GameObject DialogueCanvas;
        public AudioSource DialougeAudio;
    }

    [SerializeField]
    List<DialogueReferences> dialogueList = new List<DialogueReferences>();

    // Start is called before the first frame update
    void Start()
    {
        dialogueList[0].DialogueCanvas.transform.position = CameraXR.transform.position + new Vector3(0f, 0f, -3f);
        dialogueList[1].DialogueCanvas.transform.position = CameraXR.transform.position + new Vector3(0f, 0f, -3f);
        dialogueList[2].DialogueCanvas.transform.position = CameraXR.transform.position + new Vector3(0f, 0f, -3f);
    }

    public void DialogueSelector(int number)
    {
        Reset();
        number = 1;

        switch (number)
        {
            case 0:
                dialogueList[0].DialogueCanvas.SetActive(true);
                dialogueList[0].DialougeAudio.playOnAwake = true;
                break;

            case 1:
                dialogueList[1].DialogueCanvas.SetActive(true);
                dialogueList[1].DialougeAudio.playOnAwake = true;
                break;

            case 2:
                dialogueList[2].DialogueCanvas.SetActive(true);
                dialogueList[2].DialougeAudio.playOnAwake = true;
                break;
        }
    }

    public void Reset()
    {
        //Dialogue Canvases
        dialogueList[0].DialogueCanvas.SetActive(false);
        dialogueList[1].DialogueCanvas.SetActive(false);
        dialogueList[2].DialogueCanvas.SetActive(false);

        //Dialogue Audios
        dialogueList[0].DialougeAudio.playOnAwake = false;
        dialogueList[1].DialougeAudio.playOnAwake = false;
        dialogueList[2].DialougeAudio.playOnAwake = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class StorySceneManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneReferences
    {
        public CanvasGroup DialogueCanvas;
        public GameObject TargetAudio;
        public AudioSource DialogueAudio;
        public GameObject TargetObject;
    }
    [SerializeField]
    public List<SceneReferences> ToiletSceneList = new List<SceneReferences>();

    [SerializeField]
    private CanvasGroup StartPageCanvas;

    [SerializeField]
    private LevelLoader levelLoader;

    Outline outline;
    Scene scene;
    bool playTargetAudio = false;
    public GameObject dialoguePrefab;
    private string systemVoice;
    public bool playSystemSound = false;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        //StartCoroutine(FadeInScene());
        StartCoroutine(InternalSceneManager());
    }

    IEnumerator InternalSceneManager()
    {

        //Scene introduction
        StartPageCanvas.alpha = 1;
        yield return new WaitForSeconds(5);
        StartPageCanvas.GetComponent<CanvasGroup>().DOFade(0, 1);
        yield return new WaitUntil(()=> StartPageCanvas.alpha==0);

        int InternalSceneNumber;
        for (InternalSceneNumber = 0; InternalSceneNumber < 3; InternalSceneNumber++)
        {
            switch (InternalSceneNumber)
            {
                case 0:
                    // find phone scene
                    SetCanvasGroupActive(InternalSceneNumber);
                    yield return new WaitForSeconds(8);
                    PlayTargetAudio(InternalSceneNumber);

                    yield return new WaitForSeconds(5);
                    Highlight(InternalSceneNumber);
                    yield return new WaitUntil(() => !ToiletSceneList[InternalSceneNumber].TargetAudio.activeSelf);
                    RemoveHighlight();
                    break;

                case 1:
                    //phone notif scene
                    StartCoroutine(ShowDialogue(SystemVoice(), 0, InternalSceneNumber));
                    yield return new WaitForSeconds(12);
                    break;

                case 2:
                    // zoom meeting scene
                    SetCanvasGroupActive(InternalSceneNumber);
                    yield return new WaitForSeconds(8);
                    break;
            }
            SetCanvasGroupInactive(InternalSceneNumber);
        }

        yield return new WaitForSeconds(3);
        // levelLoader.FadeToNextScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
}

    //Set Canvas Active and Handle the Sound
    public void SetCanvasGroupActive(int InternalSceneNumber)
    {
        if (ToiletSceneList[InternalSceneNumber].DialogueCanvas != null) {
            ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha = 1;
            playTargetAudio = true;
            Debug.Log("Playing Dialogue Number:" + InternalSceneNumber);
        }

    } 

    //Set Canvas Inactive
    public void SetCanvasGroupInactive(int InternalSceneNumber)
    {
        if (ToiletSceneList[InternalSceneNumber].DialogueCanvas != null)
        {
            ToiletSceneList[InternalSceneNumber].DialogueCanvas.alpha = 0;
        }
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
        //GameObject dialogue = Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        GameObject dialogue = Instantiate(dialoguePrefab, GameObject.Find("Main Camera").transform);
        //dialogue.transform.parent = GameObject.Find("Main Camera").transform;
        PopupDialogue dialogueBox = dialogue.GetComponent<PopupDialogue>();//instantiates the dialogue prefab
        dialogueBox.text = Text; //Sets the text of the dialogue popup
        ToiletSceneList[InternalSceneNumber].DialogueAudio.Play();
        dialogueBox.exitDelay = ExitDelay; //Optional parameter to delay the exit time, just set to 0 if unused
        dialogueBox.StartDialogue(); //Shows the text after the settings are set
        //yield return new WaitUntil(() => ToiletSceneList[InternalSceneNumber].DialogueAudio.isPlaying == false); 
        yield return new WaitForSeconds(10); //Not sure what you want it to wait for, but just add in the delay here
        dialogueBox.delete(); //Deletes the popup after waiting
    }

    public string SystemVoice()
    {
        switch (scene.buildIndex)
        {
            case 1:
                systemVoice = "Temperature of water is 30 degrees celcius, hope that is not too hot for you!";
                break;

            case 2:
                systemVoice = "You have a notification: Project discussion on zoom meeting at 12.00pm, starting in 5 minutes.";
                break;
        }
        return systemVoice;
    }

    IEnumerator FadeInScene()
    {
        //fadein
        levelLoader.FadeToNextScene();
        yield return new WaitForSeconds(5);

    }

}

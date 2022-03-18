using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlManager : MonoBehaviour
{

    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject XRRig;
    public static bool ShowMenu = false;
    public GameObject FilterMenuObject;
    public GameObject PauseMenuObject;
    public InputActionReference PauseReference = null;
    public InputActionReference ResetCamReference = null;
    public InputActionReference InstructionsReference = null;

    private void Awake()
    {
        PauseReference.action.started += Pause;
        ResetCamReference.action.started += ResetCam;
        InstructionsReference.action.started += OpenInstructions;
    }

    private void OnDestroy()
    {
        PauseReference.action.started -= Pause;
        ResetCamReference.action.started -= ResetCam;
        InstructionsReference.action.started -= OpenInstructions;
    }

    private void Pause(InputAction.CallbackContext context)
    {
        ShowMenu = !ShowMenu;
        LeftHand.GetComponent<XRInteractorLineVisual>().enabled = ShowMenu;
        RightHand.GetComponent<XRInteractorLineVisual>().enabled = ShowMenu;
        if (ShowMenu)
        {
            Time.timeScale = 0;
            FilterMenuObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            FilterMenuObject.SetActive(false);
            PauseMenuObject.SetActive(false);
        }
    }

    public void CloseMenu(){
        ShowMenu = false;
        Time.timeScale = 1;
        FilterMenuObject.SetActive(false);
        PauseMenuObject.SetActive(false);
    }

    public void OpenSettingMenu(){
        FilterMenuObject.SetActive(false);
        PauseMenuObject.SetActive(true);
    }

    public void OpenFilterMenu(){
        FilterMenuObject.SetActive(true);
        PauseMenuObject.SetActive(false);
    }

    public void ResetCam(InputAction.CallbackContext context){
         XRRig.transform.rotation = Quaternion.identity;
    }

    public void OpenInstructions(InputAction.CallbackContext context){
        //whatever u want
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

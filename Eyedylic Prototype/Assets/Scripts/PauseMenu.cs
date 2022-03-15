using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Color selectColor;
    public GameObject PlayerManager;
    

    public void OpenFilterMenu(){
        PlayerManager.GetComponent<ControlManager>().OpenFilterMenu();
    }

    public void ReturnButton()
    {
        PlayerManager.GetComponent<ControlManager>().CloseMenu();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void ChangeVolume(float value)
    {
        AudioSource[] allAudioSource = FindObjectsOfType<AudioSource>();
        foreach(AudioSource aSource in allAudioSource)
        {
            aSource.volume = value;
        }
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    public GameObject FilterMenuObject;
    //public Slider SliderObject;
    

    public void OpenFilterMenu(){
        FilterMenuObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnButton()
    {
        ControlManager.ShowMenu = false;
        gameObject.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject EndPageCanvas;

    public void EndRestartButton()
    {
        SceneManager.LoadScene(0);
    }
}

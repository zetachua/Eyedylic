using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetTrigger : MonoBehaviour
{
    public GameObject TargetAudioSource;

    public void OnTriggerEnter(Collider other)
    {
        TargetAudioSource.SetActive(false);
    }
}

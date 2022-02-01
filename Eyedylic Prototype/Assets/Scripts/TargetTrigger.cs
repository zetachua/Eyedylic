using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetTrigger : MonoBehaviour
{
    InternalSceneManager sM;
    public AudioSource TargetAudioSource;

    void Start()
    {
        sM = GetComponent<InternalSceneManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        TargetAudioSource.Stop();
        TargetAudioSource.loop=false;
        sM.RemoveHighlight();
    }
}

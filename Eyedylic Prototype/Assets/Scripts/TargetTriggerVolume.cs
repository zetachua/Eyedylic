using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Assertions;

public class TargetTriggerVolume : MonoBehaviour
{
    [SerializeField] private AudioSource TargetAudioSourceReduced;
    public bool isTargetObjectInteracted;

    void Start()
    {
        Assert.IsNotNull(TargetAudioSourceReduced);
        isTargetObjectInteracted = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        isTargetObjectInteracted = true;
        TargetAudioSourceReduced.volume = 0.2f;
        Debug.Log("TriggeredTarget" + isTargetObjectInteracted);
    }
}

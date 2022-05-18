using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TargetAudioSource;
    public bool isTargetObjectInteracted;

    void Start()
    {
        isTargetObjectInteracted = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        TargetAudioSource.SetActive(false);
        isTargetObjectInteracted = true;
    }
}

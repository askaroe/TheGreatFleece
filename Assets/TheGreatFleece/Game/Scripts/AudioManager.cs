using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio manager is NULL!!");
            }
            return _instance;
        }
    }

    public AudioSource voiceOver;

    private void Awake()
    {
        _instance = this;
        
    }

    public void PLayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }
}

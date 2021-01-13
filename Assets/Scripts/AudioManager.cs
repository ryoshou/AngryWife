using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    // private static AudioManager audio_instance = null;
    // void Awake()
    // {
    //     if (audio_instance == null)
    //     {
    //         audio_instance=this;
    //         DontDestroyOnLoad(audio_instance);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    // }
    void Start()
    {
        var buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(delegate {Play("Click");});
        }
    }
    public void Play(string clipName)
    {
        AudioClip audioClip = Array.Find(clips, clip => clip.name == clipName);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

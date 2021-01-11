using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sounds;
    private static AudioManager audio_instance = null;
    void Awake()
    {
        if (audio_instance == null)
        {
            audio_instance=this;
            DontDestroyOnLoad(audio_instance);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // public void Play(string name)
    // {
    //     Sound s = Array.Find(sounds, sound => sound.name == name);
    //     if (s==null)
    //     {
    //         Debug.Log("Sound: "+ name + " not found!");
    //         return;
    //     }
    //     s.source.Play();
    // }
}

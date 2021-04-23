using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBg : MonoBehaviour
{
    public AudioSource myAudio;

    public AudioClip[] myRandomMusic;

    void Start()
    {
        PlayRandomMusic();
    }

    void Update()
    {
        if(!myAudio.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    void PlayRandomMusic()
    {
        myAudio.clip = myRandomMusic[Random.Range(0, myRandomMusic.Length)] as AudioClip;
        myAudio.Play();
    }
}

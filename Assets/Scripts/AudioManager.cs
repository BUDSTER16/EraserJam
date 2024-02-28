using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip songLoop;
    public AudioSource musicSource;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.clip = songLoop;
        musicSource.Play();
    }
}

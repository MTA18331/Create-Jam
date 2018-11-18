using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    
    public AudioClip musicOn; // Contains/ Holds the audio clip 
    public AudioSource musicSource; // Controls the audio clip

    private void Start()
    {
        playSound();
    }

    void playSound()
    {
        musicSource.clip = musicOn; // Assigns the AudioSource clip to the AudioClip
        musicSource.PlayOneShot(musicOn); // Plays the audio clip
    }
    void stopSound()
    {
        musicSource.Stop();
    }
}

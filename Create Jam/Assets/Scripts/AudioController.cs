using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public GameObject gameObject;
	void findAudioSOurce()
    {
        gameObject.GetComponent<AudioSource>();
        Audio audio = new Audio();
        audio.playSound();
    }
}

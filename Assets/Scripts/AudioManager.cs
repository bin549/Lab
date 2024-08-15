using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip introClip;

    private void Awake() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = this.introClip;
        audioSource.playOnAwake = false;
    }

    public void Play() {
        this.audioSource.Play();
    }
    
    public void Stop() {
        this.audioSource.Stop();
    }
}
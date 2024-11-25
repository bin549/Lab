using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;

    private void Awake() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void Play() {
        this.audioSource.Play();
    }

    public void Stop() {
        this.audioSource.Stop();
    }
}
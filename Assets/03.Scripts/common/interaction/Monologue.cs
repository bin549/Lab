using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct MonologueClip{
    public AudioClip audioClip;
    public string subtitle;
}

[RequireComponent(typeof(AudioSource))]
public class Monologue : MonoBehaviour { 
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI subtitleText;
    private AudioSource audioSource;
    
    private void Awake() { 
        this.audioSource = this.gameObject.GetComponent<AudioSource>();
        this.image = this.gameObject.GetComponent<Image>();
    }

    private void Start() {
        this.DisplayUI(false);
    }

    public void Play(MonologueClip monologueClip) {
        this.DisplayUI(true);
        this.audioSource.clip = monologueClip.audioClip;
        this.subtitleText.text = monologueClip.subtitle;
        this.audioSource.Play();
        StartCoroutine(DisenableUI(this.audioSource.clip.length));
    }

    private IEnumerator DisenableUI(float seconds) {
        yield return new WaitForSeconds(seconds);
        this.DisplayUI(false);
    }

    private void DisplayUI(bool isActive) {
        this.image.enabled = isActive;
        this.subtitleText.gameObject.SetActive(isActive);
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundRecorder : InteractableItem {
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    protected override void Awake() { 
        base.Awake();
        this.audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        this.audioSource.clip = this.audioClip;
        base.interactableObject.DetectedText.text = "播放";
    }

    protected override void Update() {
        base.Update();
    }

    public void OnInteract() {
        base.InteractAction();
        this.InteractAction();
    }
    
    protected override void InteractAction() {
        if (base.interactableObject.DetectedText.text == "播放") {
            base.InteractAction();
            base.interactableObject.DetectedText.text = "停止";
            StartCoroutine(this.OnRecordPlay());
        } else {
            this.audioSource.Stop();
            base.interactableObject.DetectedText.text = "播放";
        }
    }

    private IEnumerator OnRecordPlay() {
        yield return new WaitForSeconds(0.0f);
        this.audioSource.Play();
    }
}
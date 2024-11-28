using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Gramophone : InteractableItem {
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private RecordPlayer recordPlayer;
    
    protected override void Awake() {
        base.Awake();
        this.audioSource = GetComponent<AudioSource>();
        this.recordPlayer = GetComponentInChildren<RecordPlayer>();
    }

    private void Start() {
        this.audioSource.clip = this.audioClip;
        base.interactableObject.DetectedText.text = "播放";
    }
    
    protected override void Update() {
        base.Update();
    }

    protected override void InteractAction() {
        if (base.interactableObject.DetectedText.text == "播放") {
            base.InteractAction();
            this.recordPlayer.RecordPlayerActive = true;
            base.interactableObject.DetectedText.text = "停止";
            StartCoroutine(this.OnRecordPlay());
        } else {
            this.recordPlayer.RecordPlayerActive = false; 
            this.audioSource.Stop();
            base.interactableObject.DetectedText.text = "播放";
        }
    }

    private IEnumerator OnRecordPlay() {
        yield return new WaitForSeconds(1.0f);
        this.audioSource.Play();
    }
}
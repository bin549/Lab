using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Gramophone : InteractableItem {
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    protected override void Awake() {
        base.Awake();
        this.audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        this.audioSource.clip = this.audioClip;
        base.interactableObject.DetectedText.text = "Play";
    }
    
    protected override void Update() {
        base.Update();
    }

    protected override void InteractAction() {
        if (base.interactableObject.DetectedText.text == "Play") {
            this.audioSource.Play();
            base.interactableObject.DetectedText.text = "Stop";
        } else {
            this.audioSource.Stop();
            base.interactableObject.DetectedText.text = "Play";
        }
    }
}
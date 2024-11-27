using System;
using TMPro;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI originText, detectedText;

    public TextMeshProUGUI DetectedText => detectedText;

    public bool IsInteractable() {
        return this.detectedText.gameObject.activeSelf;
    }
    
    public void OnHintToggle(bool isToggle) {
        this.originText.gameObject.SetActive(!isToggle);
        this.detectedText.gameObject.SetActive(isToggle);
    }
    
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.OnHintToggle(true);
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.OnHintToggle(false);
        }
    }
}
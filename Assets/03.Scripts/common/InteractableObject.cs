using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] private GameObject originText, detectedText;

    public bool IsInteractable() {
        return this.detectedText.activeSelf;
    }
    
    public void OnHintToggle(bool isToggle) {
        this.originText.SetActive(!isToggle);
        this.detectedText.SetActive(isToggle);
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
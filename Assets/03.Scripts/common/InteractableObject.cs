using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] private GameObject originText, detectedText;
    [SerializeField] private CapsuleCollider playerCollider;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.detectedText.activeSelf) {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.originText.SetActive(false);
            this.detectedText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.originText.SetActive(true);
            this.detectedText.SetActive(false);
        }
    }
}
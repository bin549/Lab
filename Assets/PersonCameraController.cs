using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCameraController : MonoBehaviour {
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeReference] private InteractableDetector firstInterationObjectDetector;
    [SerializeReference] private BoxCollider thirdInterationObjectDetector;

    private void Awake() {
        this.firstPersonController = this.GetComponent<FirstPersonController>();
        this.thirdPersonController = this.GetComponent<ThirdPersonController>();
        this.firstInterationObjectDetector = this.GetComponent<InteractableDetector>();
        this.thirdInterationObjectDetector = this.GetComponent<BoxCollider>();
    }

    public void HideCamera() {
        this.firstPersonController.mPlayerCamera.gameObject.SetActive(false);
        this.thirdPersonController.mPlayerCamera.gameObject.SetActive(false);
    }
    
    public void ChangeViewCamera() {
        if (this.firstPersonController.enabled) {
            this.thirdPersonController.enabled = true;
            this.firstPersonController.enabled = false;
        } else {
            this.thirdPersonController.enabled = false;
            this.firstPersonController.enabled = true;
        }
        this.firstPersonController.mPlayerCamera.gameObject.SetActive(this.firstPersonController.enabled);
        this.thirdPersonController.mPlayerCamera.gameObject.SetActive(this.thirdPersonController.enabled);
        this.firstInterationObjectDetector.enabled = this.firstPersonController.enabled;
        this.thirdInterationObjectDetector.enabled = this.thirdPersonController.enabled;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            this.ChangeViewCamera();
        }
    }
}
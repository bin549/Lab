using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCameraController : MonoBehaviour {
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeReference] private BoxCollider interationObjectDetector;

    private void Awake() {
        this.firstPersonController = this.GetComponent<FirstPersonController>();
        this.thirdPersonController = this.GetComponent<ThirdPersonController>();
        this.interationObjectDetector = this.GetComponent<BoxCollider>();
    }
    
    private void ChangeViewCamera() {
        if (this.firstPersonController.enabled) {
            this.thirdPersonController.enabled = true;
            this.firstPersonController.enabled = false;
        } else {
            this.thirdPersonController.enabled = false;
            this.firstPersonController.enabled = true;
        }
        this.firstPersonController.mPlayerCamera.gameObject.SetActive(this.firstPersonController.enabled);
        this.thirdPersonController.mPlayerCamera.gameObject.SetActive(this.thirdPersonController.enabled);
        this.interationObjectDetector.enabled = this.thirdPersonController.enabled;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            this.ChangeViewCamera();
        }
    }
}
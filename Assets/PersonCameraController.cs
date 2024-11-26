using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCameraController : MonoBehaviour {
    private FirstPersonController firstPersonController;
    private ThirdPersonController thirdPersonController;
    private InteractableDetector firstInterationObjectDetector;
    private BoxCollider thirdInterationObjectDetector;
    private GameManager gameManager;

    private void Awake() {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.firstPersonController = this.GetComponent<FirstPersonController>();
        this.thirdPersonController = this.GetComponent<ThirdPersonController>();
        this.firstInterationObjectDetector = this.GetComponent<InteractableDetector>();
        this.thirdInterationObjectDetector = this.GetComponent<BoxCollider>();
    }

    private void Start() {
        if ((this.gameManager.IsFirstPersonView && !this.firstPersonController.enabled) || (!this.gameManager.IsFirstPersonView && !this.thirdPersonController.enabled)) {
               this.ChangeViewCamera();
        }
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
            this.gameManager.IsFirstPersonView = !this.gameManager.IsFirstPersonView;
            this.ChangeViewCamera();
        }
    }
}
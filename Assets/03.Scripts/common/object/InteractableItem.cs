using System;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class InteractableItem : MonoBehaviour {
    [HideInInspector] protected InteractableObject interactableObject;

    protected virtual void Awake() {
        this.interactableObject = GetComponent<InteractableObject>();
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.interactableObject.IsInteractable()) {
            this.InteractAction();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.DeactiveAction();
        }
    }

    protected virtual void InteractAction() {
    }

    protected virtual void DeactiveAction() {
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem : MonoBehaviour {
    protected LabObject labObject;

    protected virtual void Awake() {
        this.labObject = this.GetComponent<LabObject>();
    }

    protected virtual void CheckMouseButton() {
        if (Input.GetMouseButtonDown(0) && this.labObject.LabDetector.IsFocus) {
            if (Camera.main == null) {
                Debug.LogError("No camera tagged as MainCamera found.");
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == transform) {
                    this.OnSingleClick();
                    Debug.Log("Base OnSingleClick called");
                }
            }
        }
    }

    protected virtual void OnSingleClick() {
    }

    protected virtual void TakeOnAction() {
        this.labObject.LabDetector.IncreateTip();
    }
}
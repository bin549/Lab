using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LabObject))]
public class LabItem0101Cube : LabItem {
    [SerializeField] private LabItem0101SlopePoint labItem0101SlopePoint;
    [SerializeField] private GridItem displayIcon;
        
    private void Update() {
        this.CheckMouseButton();
    }
    
    protected virtual void CheckMouseButton() {
        if (Input.GetMouseButtonDown(0) && this.labObject.LabDetector.IsFocus) {
            if (Camera.main == null) {
                Debug.LogError("No camera tagged as MainCamera found.");
                return;
            }
            OnSingleClick();
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // RaycastHit hit;
            // if (Physics.Raycast(ray, out hit)) {
            //     if (hit.transform == transform) {
            //         OnSingleClick();
            //     }
            // }
        }
    }

    
    protected override void OnSingleClick() {
        this.TakeOnAction();
    } 
    
    protected override void TakeOnAction() {
        this.gameObject.SetActive(false);
        this.labItem0101SlopePoint.gameObject.SetActive(true);
        this.displayIcon.gameObject.SetActive(true);
        base.TakeOnAction();
    }
}
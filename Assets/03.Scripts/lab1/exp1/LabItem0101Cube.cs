using System;
using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem0101Cube : LabItem {
    [SerializeField] private LabItem0101SlopePoint labItem0101SlopePoint;
    
    private void Update() {
        base.CheckMouseButton();
    }
    
    protected override void OnSingleClick() {
        this.TakeOnAction();
    } 
    
    protected override void TakeOnAction() {
        this.gameObject.SetActive(false);
        this.labItem0101SlopePoint.gameObject.SetActive(true);
        base.TakeOnAction();
    }
}
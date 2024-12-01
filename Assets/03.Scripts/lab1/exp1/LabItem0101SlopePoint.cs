using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem0101SlopePoint : LabItem {
    
    private void Update() {
        base.CheckMouseButton();
    }
    
    protected override void OnSingleClick() {
        this.TakeOnAction();
    } 
    
    protected override void TakeOnAction() {
        this.gameObject.SetActive(false);
        base.TakeOnAction();
    }
}
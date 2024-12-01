using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem0101SlopePoint : LabItem {
    [SerializeField] private GridItem gridItem;
    
    private void Update() {
        this.CheckMouseButton();
    }

    protected virtual void CheckMouseButton() {
        if (Input.GetMouseButtonDown(0) && this.labObject.LabDetector.IsFocus && this.gridItem.IsActive) {
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
        this.gridItem.gameObject.SetActive(false);
        base.TakeOnAction();
    }
}
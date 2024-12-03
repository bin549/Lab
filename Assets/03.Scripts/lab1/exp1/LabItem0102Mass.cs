using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem0102Mass : LabItem {
    [SerializeField] private GridItem displayIcon;
    [SerializeField] private GameObject massMesh;

    private void Update() {
        this.CheckMouseButton();
        this.C();
    }

    private void C() {
        if (Input.GetKeyDown(KeyCode.C)) {
            GetComponent<LabObject>().OnDoubleClick();
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            GetComponent<LabObject>().HiddenObject();
        }
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
        this.massMesh.gameObject.SetActive(false);
        // this.enabled = false;
        this.displayIcon.gameObject.SetActive(true);
        if (!this.massMesh.gameObject.activeSelf) {
            return;
        }
        base.TakeOnAction();
    }
}
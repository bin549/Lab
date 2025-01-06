using UnityEngine;

[RequireComponent(typeof(LabObject))]
public class LabItem0201Power : LabItem {
    private void Update() {
        this.Z();
    }

    private void Z() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            GetComponent<LabObject>().OnDoubleClick();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            GetComponent<LabObject>().HiddenObject();
        }
    }
}
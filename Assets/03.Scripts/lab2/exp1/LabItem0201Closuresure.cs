using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabItem0201Closuresure : LabItem {
    private void Update() {
        this.X();
    }

    private void X() {
        if (Input.GetKeyDown(KeyCode.X)) {
            GetComponent<LabObject>().OnDoubleClick();
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            GetComponent<LabObject>().HiddenObject();
        }
    }
}
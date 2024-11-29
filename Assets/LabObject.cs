using UnityEngine;

public class LabObject : MonoBehaviour {
    private float lastClickTime = 0f;
    private const float doubleClickDelay = 0.3f;
    [SerializeField] private GameObject observeCamera;
    [SerializeField] private GameObject objectCamera;

    private void Update() {
        this.CheckMouseButton();
        this.CheckExitButton();
    }

    private void CheckMouseButton() {
        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - lastClickTime < doubleClickDelay) {
                OnDoubleClick();
            }
            lastClickTime = Time.time;
        }
    }

    private void CheckExitButton() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == transform) {
                    if (Time.time - lastClickTime < doubleClickDelay) {
                        OnDoubleClick();
                    }
                    lastClickTime = Time.time;
                }
            }
        }
    }

    private void OnDoubleClick() {
        this.observeCamera.gameObject.SetActive(false);
        this.objectCamera.gameObject.SetActive(true);
    }
}
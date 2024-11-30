using UnityEngine;
using Cinemachine;

public class LabObject : MonoBehaviour {
    private float lastClickTime = 0f;
    private const float doubleClickDelay = 0.3f;

    [SerializeField] private LabDetector labDetector;
    [SerializeField] private CinemachineVirtualCamera objectCamera;

    private void Update() {
        CheckMouseButton();
        CheckExitButton();
    }

    private void CheckMouseButton() {
        if (Input.GetMouseButtonDown(0)) {
            if (Camera.main == null) {
                Debug.LogError("No camera tagged as MainCamera found.");
                return;
            }
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

    private void CheckExitButton() {
        if (Input.GetMouseButtonDown(1) && this.labDetector.IsFocus) {
            this.labDetector.IsFocus = false;
            this.labDetector.VirtualCamera.gameObject.SetActive(true);
            objectCamera.gameObject.SetActive(false);
            objectCamera.Priority = 0;
        }
    }

    private void OnDoubleClick() {
        this.labDetector.IsFocus = true;
        this.labDetector.VirtualCamera.gameObject.SetActive(false);
        objectCamera.gameObject.SetActive(true);
        objectCamera.Priority = 10;
        this.labDetector.VirtualCamera.Priority = 0;
    }
}
using System.Collections;
using UnityEngine;
using Cinemachine;

public class LabObject : MonoBehaviour {
    private float lastClickTime = 0f;
    private const float doubleClickDelay = 0.3f;
    [SerializeField] private LabDetector labDetector;
    [SerializeField] private CinemachineVirtualCamera objectCamera;

    public LabDetector LabDetector {
        get => labDetector;
    }

    private void Awake() {
        this.objectCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>(true);
    }

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
                        this.OnDoubleClick();
                    }
                    lastClickTime = Time.time;
                }
            }
        }
    }

    private void CheckExitButton() {
        if (Input.GetMouseButtonDown(1) && this.labDetector.IsFocus) {
            this.HiddenObject();
        }
    }

    private void SetFocusCamera(bool isFocus) {
        if (this.objectCamera == null || this.labDetector.VirtualCamera == null) {
            Debug.LogError("Camera or VirtualCamera is null.");
            return;
        }
        if (isFocus) {
            this.objectCamera.enabled = true;
            this.objectCamera.Priority = 10;
            this.labDetector.VirtualCamera.Priority = 0;
            this.labDetector.VirtualCamera.enabled = false;
        } else {
            this.objectCamera.Priority = 0;
            this.objectCamera.enabled = false;
            this.labDetector.VirtualCamera.enabled = true;
            this.labDetector.VirtualCamera.Priority = 10;
        }
    }

    public void HiddenObject() {
        this.SetFocusCamera(false);
        this.labDetector.IsFocus = false;
    }
    
    public void OnDoubleClick() {
        this.SetFocusCamera(true);
        StartCoroutine(this.EnableActive());
    }

    private IEnumerator EnableActive() {
        yield return new WaitForSeconds(0.3f);
        this.labDetector.IsFocus = true;
    }
}
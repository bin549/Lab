using UnityEngine;

public class LabItemObserveCamera : MonoBehaviour {
    public Transform target;
    public float distance = 3.0f;
    public float rotationSpeed = 550.0f;
    private float currentX = 0f;
    private float currentY = 0f;

    private void Start() {
        UpdatePosition();
        transform.LookAt(target.position);
    }

    private void LateUpdate() {
        if (Input.GetMouseButton(0)) {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, -45f, 45f);
        }
        UpdatePosition();
        transform.LookAt(target.position);
    }

    private void UpdatePosition() {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = rotation * Vector3.back;
        transform.position = target.position + direction * distance;
    }
}
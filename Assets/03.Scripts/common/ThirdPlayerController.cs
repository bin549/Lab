using System;
using UnityEngine;

public class ThirdPlayerController : MonoBehaviour {
    [SerializeReference] private GameObject firstCamera;
    public float moveSpeed = 5f;
    public Camera mainCamera;
    [SerializeReference] private Animator animator;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            firstCamera.SetActive(!firstCamera.activeSelf);
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        if (inputDirection.magnitude > 0) {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
            Vector3 moveDirection = (cameraForward * inputDirection.z + cameraRight * inputDirection.x).normalized;
            if (moveDirection != Vector3.zero) {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,
                    720 * Time.deltaTime);
            }
            animator.SetFloat("Speed", moveDirection.magnitude * moveSpeed);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        } else {
            animator.SetFloat("Speed", 0);
        }
    }
}
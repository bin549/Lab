using System;
using Cinemachine;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {
    [SerializeReference] private GameObject firstCamera;
    public Camera mainCamera;
    [SerializeReference] private Animator animator;
    public float rotationSmoothTime = 0.1f; 
    public float acceleration = 10f;
    public float deceleration = 5f; 
    private Vector3 currentVelocity; 
    public float walkSpeed = 2f; 
    public float runSpeed = 4f;
    public CinemachineFreeLook mPlayerCamera = null;

    private void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        float currentSpeed = 0f;
        if (inputDirection.magnitude > 0) {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
            Vector3 moveDirection = (cameraForward * inputDirection.z + cameraRight * inputDirection.x).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime * Time.deltaTime);
            currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            Vector3 targetVelocity = moveDirection * currentSpeed;
            if (moveDirection != Vector3.zero) {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,
                    720 * Time.deltaTime);
            }
            currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        } else {    
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);
        }
        animator.SetFloat("speed", currentSpeed);
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);
    }
}
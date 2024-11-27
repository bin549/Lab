using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : PersonController {
    [SerializeField] private float mMoveSpeed = 7.5f;
    [SerializeField] private float mLookSpeed = 2.0f;
    [SerializeField] private float mLookXLimit = 45.0f;
    [SerializeField] private float mMouseResetDeadzone = 0.1f;
    private CharacterController mCharacterController = null;
    private float mRotationX = 0;

    protected override void Awake() {
        base.Awake();
        base.mPlayerCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        this.mCharacterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        base.SetInputEnabled(true);
    }

    private void Update() {
        this.PlayerMove();
        // this.SelectItem();
    }

    protected override void PlayerMove() {
        if (base.gameManager.IsBusy) {
            return;
        }
        Vector2 inputDir = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * mMoveSpeed;
        base.playerAnimate.UpdateSpeed(inputDir.magnitude);
        Vector3 moveDir = (transform.forward * inputDir.x) + (transform.right * inputDir.y);
        this.mCharacterController.Move(moveDir * Time.deltaTime);
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        if (mouseInput.magnitude < mMouseResetDeadzone) {
            this.mReset = true;
        }
        if (this.mReset) {
            mRotationX += mouseInput.y * mLookSpeed;
            mRotationX = Mathf.Clamp(mRotationX, -mLookXLimit, mLookXLimit);
            mPlayerCamera.transform.localRotation = Quaternion.Euler(mRotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseInput.x * mLookSpeed, 0);
        }
    }
}
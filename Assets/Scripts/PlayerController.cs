using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float mMoveSpeed = 7.5f;
    [SerializeField] private float mLookSpeed = 2.0f;
    [SerializeField] private float mLookXLimit = 45.0f;
    [SerializeField] private float mMouseResetDeadzone = 0.1f;
    [SerializeField] private GameObject mUiBorder = null;

    private CharacterController mCharacterController = null;
    public CinemachineVirtualCamera mPlayerCamera = null;
    private float mRotationX = 0;
    private bool mCanMove = true;
    private bool mReset = false;

    private void Awake() {
        this.mCharacterController = GetComponent<CharacterController>();
        this.mPlayerCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetInputEnabled(true);
    }

    private void Update() {
        this.PlayerMove();
        // this.SelectItem();
    }

    private void PlayerMove() {
        if (!this.mCanMove) {
            return;
        }
        Vector2 inputDir = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * mMoveSpeed;
        Vector3 moveDir = (transform.forward * inputDir.x) + (transform.right * inputDir.y);
        this.mCharacterController.Move(moveDir * Time.deltaTime);
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        if (mouseInput.magnitude < mMouseResetDeadzone) {
            mReset = true; 
        }
        if (mReset) {
            mRotationX += mouseInput.y * mLookSpeed;
            mRotationX = Mathf.Clamp(mRotationX, -mLookXLimit, mLookXLimit);
            mPlayerCamera.transform.localRotation = Quaternion.Euler(mRotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseInput.x * mLookSpeed, 0);
        }
    }


    public void SetInputEnabled(bool v) {
        mUiBorder.SetActive(!v);
        mCanMove = v;
        mReset = false;
    }
}
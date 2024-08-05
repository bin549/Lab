using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mMoveSpeed = 7.5f;
    [SerializeField] private float mLookSpeed = 2.0f;
    [SerializeField] private float mLookXLimit = 45.0f;
    [SerializeField] private float mMouseResetDeadzone = 0.1f;
    [SerializeField] private GameObject mUiBorder = null;

    private CharacterController mCharacterController = null;
    private Camera mPlayerCamera = null;
    private float mRotationX = 0;
    private bool mCanMove = true;
    private bool mReset = false;
    private Transform highlightItem;
    private Transform selectionItem;

    private void Awake()
    {
        mCharacterController = GetComponent<CharacterController>();
        mPlayerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetInputEnabled(true);
    }

    private void Update()
    {
        this.PlayerMove();
        this.DetectItem();
        this.SelectItem();
    }

    private void PlayerMove()
    {
        if (!mCanMove) 
        {
            return;
        }
        Vector2 inputDir = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * mMoveSpeed;
        Vector3 moveDir = (transform.forward * inputDir.x) + (transform.right * inputDir.y);
        mCharacterController.Move(moveDir * Time.deltaTime);
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        if (mouseInput.magnitude < mMouseResetDeadzone)
        {
            mReset = true; 
        }
        if (mReset)
        {
            mRotationX += mouseInput.y * mLookSpeed;
            mRotationX = Mathf.Clamp(mRotationX, -mLookXLimit, mLookXLimit);
            mPlayerCamera.transform.localRotation = Quaternion.Euler(mRotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseInput.x * mLookSpeed, 0);
        }
    }

    private void DetectItem()
    {
        if (this.highlightItem != null)
        {
            this.highlightItem.gameObject.GetComponent<Outline>().enabled = false;
            this.highlightItem = null;
        }
        Ray r = new Ray(mPlayerCamera.transform.position, mPlayerCamera.transform.forward);
        if (Physics.Raycast(r, out RaycastHit hit))
        {
            this.highlightItem = hit.transform;
            if (this.highlightItem.CompareTag("Selectable") && this.highlightItem != this.selectionItem)
            {
                if (this.highlightItem.gameObject.GetComponent<Outline>() != null)
                {
                    this.highlightItem.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = this.highlightItem.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    this.highlightItem.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    this.highlightItem.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                this.highlightItem = null;
            }
        }
    }

    private void SelectItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = new Ray(mPlayerCamera.transform.position, mPlayerCamera.transform.forward);
            if (Physics.Raycast(r, out RaycastHit hit))
            {
                if (this.highlightItem)
                {
                    if (this.selectionItem != null)
                    {
                        this.selectionItem.gameObject.GetComponent<Outline>().enabled = false;
                    }
                    this.selectionItem = hit.transform;
                    this.selectionItem.gameObject.GetComponent<Outline>().enabled = true;
                    this.highlightItem = null;
                }
                else
                {
                    if (this.selectionItem)
                    {
                        this.selectionItem.gameObject.GetComponent<Outline>().enabled = false;
                        this.selectionItem = null;
                    }
                }
                LinePuzzle puzzle = hit.transform.GetComponent<LinePuzzle>();
                if (puzzle)
                {
                    puzzle.Focus(this);
                }
                LabItem labItem = hit.transform.GetComponent<LabItem>();
                if (labItem)
                {
                    labItem.Focus(this);
                }
            }
        }
    }

    public void SetInputEnabled(bool v)
    {
        mUiBorder.SetActive(!v);
        mCanMove = v;
        mReset = false;
    }
}
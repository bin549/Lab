using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LabDetector : MonoBehaviour {
    [SerializeField] private GameObject labHoverUI;
    [SerializeField] private GameObject labActiveUI;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool isActive = false;
    private string title = "斜面上静摩擦和动摩擦";
    private string introduction = "这是一个模拟箱子被绳子拉着沿着水平面移动的过程。学生可以通过模拟来探索静摩擦和动摩擦的影响，以及它们与表面法向力的关系。";
    private string step =  "第一步，第二步，第三步";
    private bool isFinishied = false;
    private PlayerController mControllerRef = null;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LabOne labOne;
    [SerializeField] private GameObject passObj;
    [SerializeField] private GameObject unpassObj;

    public bool IsActive {
        get {
            return this.isActive;
        }
        set {
            isActive = value;
        }
    }

    private void Awake() { 
        this.labOne = GameObject.FindObjectOfType<LabOne>();
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start() {
        this.virtualCamera.gameObject.SetActive(false);
        this.SetIsPasssIndicate();
    }

    private void SetIsPasssIndicate() {
        if (this.labOne.IsDone) {
            this.passObj.SetActive(true);
        } else {
            this.unpassObj.SetActive(true);
        }
    }

    private void Update() {
        this.UnFocusHandle();
        transform.Rotate(0, 0, 100f * Time.deltaTime);
    }

    public void HoverUI(bool isHover) {
        this.labHoverUI.SetActive(isHover);
    }

    public void Focus(PlayerController controller) {
        this.IsActive = true;
        this.gameManager.IsBusy = true;
        this.mControllerRef = controller;
        this.mControllerRef.SetInputEnabled(false); 
        this.labActiveUI.SetActive(true);
        this.virtualCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.passObj.SetActive(false);
        this.unpassObj.SetActive(false);
    }

    public void UnFocusHandle() {
        if (!this.gameManager.IsBusy) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.ExitLab(false);
        }
    }

    public void ExitLab(bool isPassed) {
        if (isPassed) {
            this.labOne.IsDone = true;
        }
        this.labActiveUI.SetActive(false);
        this.mControllerRef.SetInputEnabled(true); 
        this.mControllerRef.mUiBorder.SetActive(false);
        this.SetIsPasssIndicate();
        StartCoroutine(this.DisableBusy());
        this.virtualCamera.gameObject.SetActive(false);
        this.IsActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
        this.mControllerRef.transform.Rotate(1, 0, 0);
    }

    private IEnumerator DisableBusy() {
        yield return new WaitForSeconds(.4f);
        this.gameManager.IsBusy = false;
    }
}

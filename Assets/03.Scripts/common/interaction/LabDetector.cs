using System.Collections;
using UnityEngine;
using Cinemachine;

public class LabDetector : InteractableItem {
    [SerializeField] private GameObject labActiveUI;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool isActive = false;
    private string title = "斜面上静摩擦和动摩擦";
    private string introduction = "这是一个模拟箱子被绳子拉着沿着水平面移动的过程。学生可以通过模拟来探索静摩擦和动摩擦的影响，以及它们与表面法向力的关系。";
    private string step = "第一步，第二步，第三步";
    private bool isFinishied = false;
    [SerializeField] private GameManager gameManager;
    [SerializeField] public LabOne labOne;

    public bool IsActive {
        get { return this.isActive; }
        set { isActive = value; }
    }

    protected override void Awake() {
        base.Awake();
        this.labOne = GameObject.FindObjectOfType<LabOne>();
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start() {
        this.virtualCamera.gameObject.SetActive(false);
    }

    protected override void Update() {
        base.Update();
    }

    protected override void InteractAction() {
        PersonController controller = FindObjectOfType<PersonController>();
        this.Focus(controller);
    }

    protected override void DeactiveAction() {
        if (!this.gameManager.IsBusy) {
            return;
        }
        this.ExitLab(false);
    }

    public void Focus(PersonController controller) {
        this.IsActive = true;
        this.gameManager.IsBusy = true;
        this.labActiveUI.SetActive(true);
        GameObject.FindObjectOfType<PersonCameraController>().GetPersonController().mPlayerCamera.gameObject
            .SetActive(false);
        this.virtualCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void ExitLab(bool isPassed) {
        if (isPassed) {
            this.labOne.IsDone = true;
        }
        this.labActiveUI.SetActive(false);
        StartCoroutine(this.DisableBusy());
        GameObject.FindObjectOfType<PersonCameraController>().GetPersonController().mPlayerCamera.gameObject
            .SetActive(true);
        this.virtualCamera.gameObject.SetActive(false);
        this.IsActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator DisableBusy() {
        yield return new WaitForSeconds(.4f);
        this.gameManager.IsBusy = false;
    }
}
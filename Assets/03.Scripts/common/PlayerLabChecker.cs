using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLabChecker : MonoBehaviour {
    [SerializeField] private Transform hoverItem;
    private Transform activeItem;
    private FirstPlayerController FirstPlayerController;
    [SerializeField] private GameManager gameManager;

    private void Awake() {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.FirstPlayerController = GetComponent<FirstPlayerController>();
    }

    private void Update() {
        this.DetectLab();
        this.ActiveExpUI();
    }

    private void DetectLab() {
        if (this.gameManager.IsBusy) {
            return;
        }
        if (this.hoverItem) {
            if (this.hoverItem.gameObject.GetComponent<LabDetector>()) {
                this.hoverItem.gameObject.GetComponent<LabDetector>().HoverUI(false);
                this.hoverItem = null;
            }
        }
        GetComponent<FirstPlayerController>().mUiBorder.SetActive(false);
        Ray r = new Ray(FirstPlayerController.mPlayerCamera.transform.position,
            FirstPlayerController.mPlayerCamera.transform.forward);
        if (Physics.Raycast(r, out RaycastHit hit)) {
            this.hoverItem = hit.transform;
            if (this.hoverItem.CompareTag("LabDetector")) {
                GetComponent<FirstPlayerController>().mUiBorder.SetActive(true);
                this.hoverItem = hit.transform;
                this.hoverItem.transform.gameObject.GetComponent<LabDetector>().HoverUI(true);
            }
        }
    }

    private void ActiveExpUI() {
        if (Input.GetMouseButtonDown(0)) {
            if (this.hoverItem & this.hoverItem.CompareTag("LabDetector")) {
                this.hoverItem.gameObject.GetComponent<LabDetector>().HoverUI(false);
                this.hoverItem.transform.gameObject.GetComponent<LabDetector>().Focus(this.FirstPlayerController);
            }
        }
    }
}
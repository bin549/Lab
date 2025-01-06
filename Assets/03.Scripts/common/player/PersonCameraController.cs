using UnityEngine;

public class PersonCameraController : MonoBehaviour {
    private FirstPersonController firstPersonController;
    private ThirdPersonController thirdPersonController;
    private InteractableDetector firstInterationObjectDetector;
    private BoxCollider thirdInterationObjectDetector;
    private GameManager gameManager;
    private GameObject cursor;

    private void Awake() {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.firstPersonController = this.GetComponent<FirstPersonController>();
        this.thirdPersonController = this.GetComponent<ThirdPersonController>();
        this.firstInterationObjectDetector = this.GetComponent<InteractableDetector>();
        this.thirdInterationObjectDetector = this.GetComponent<BoxCollider>();
        this.cursor = GameObject.Find("Cursor");
    }

    private void Start() {
        if ((this.gameManager.IsFirstPersonView && !this.firstPersonController.enabled) ||
            (!this.gameManager.IsFirstPersonView && !this.thirdPersonController.enabled)) {
            this.ChangeViewCamera();
        }
    }

    public PersonController GetPersonController() {
        if (this.firstPersonController.enabled) {
            return this.firstPersonController;
        } else {
            return this.thirdPersonController;
        }
    }

    public void HideCamera() {
        this.GetPersonController().mPlayerCamera.gameObject.SetActive(false);
    }

    public void ChangeViewCamera() {
        if (this.firstPersonController.enabled) {
            this.thirdPersonController.enabled = true;
            this.firstPersonController.enabled = false;
        } else {
            this.thirdPersonController.enabled = false;
            this.firstPersonController.enabled = true;
        }
        GameObject playerFootsteps = GameObject.FindObjectOfType<PlayerFootsteps>(true).gameObject;
        playerFootsteps.GetComponent<AudioSource>().volume = 0f;
        playerFootsteps.SetActive(this.firstPersonController.enabled);
        this.cursor.SetActive(this.firstPersonController.enabled);
        this.firstPersonController.mPlayerCamera.gameObject.SetActive(this.firstPersonController.enabled);
        this.thirdPersonController.mPlayerCamera.gameObject.SetActive(this.thirdPersonController.enabled);
        this.firstInterationObjectDetector.enabled = this.firstPersonController.enabled;
        this.thirdInterationObjectDetector.enabled = this.thirdPersonController.enabled;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T) && !this.gameManager.IsBusy) {
            this.gameManager.IsFirstPersonView = !this.gameManager.IsFirstPersonView;
            this.ChangeViewCamera();
        }
    }
}
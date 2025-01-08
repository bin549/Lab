using System.Collections;
using Cinemachine;
using UnityEngine;

public class BulletinBoard : InteractableItem {
    [SerializeField] private GameObject bulletinPrefab;
    public GameObject BulletinPrefab => bulletinPrefab;
    [SerializeField] private bool isVoiceCheck = false;
    [SerializeField] private bool is3DObject = false;
    [SerializeField] private bool isPickupable = false;
    private Camera mainCamera;
    [SerializeField] private GameObject vfxObject;
    [SerializeField] private GameObject uiObject;
    [SerializeField] private GameManager gameManager;

    protected override void Awake() {
        base.Awake();
        this.mainCamera = Camera.main;
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    protected override void Update() {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape) && base.isInteracting) {
            this.DeactiveAction();
        }
    }

    public void DisplayBulletin(bool isDisplay) {
        base.isInteracting = isDisplay;
        if (this.gameManager.IsFirstPersonView) {
            this.gameManager.MuteFootsteps(true);
            GameObject.FindObjectOfType<PersonCameraController>().Cursor.SetActive(!isDisplay);
        }
        this.bulletinPrefab.SetActive(isDisplay);
    }

    protected override void InteractAction() {
        GameObject.FindObjectOfType<PlayerAnimate>().UpdateSpeed(0f);
        if (!this.bulletinPrefab.activeSelf) {
            if (this.isVoiceCheck) {
                base.InteractAction();
                StartCoroutine(this.WaitAndPrint());
            } else {
                DisplayBoard();
            }
        } else {
            this.DeactiveAction();
        }
    }

    private IEnumerator WaitAndPrint() {
        yield return new WaitForSeconds(1.0f);
        DisplayBoard();
    }

    private void DisplayBoard() {
        if (this.is3DObject) {
            this.mainCamera.gameObject.SetActive(false);
        }
        if (isPickupable) {
            gameObject.GetComponent<LineRenderer>().enabled = false;
            this.vfxObject.SetActive(false);
            this.uiObject.SetActive(false);
        }
        this.gameManager.IsBusy = true;
        PersonCameraController personCameraController = GameObject.FindObjectOfType<PersonCameraController>();
        if (this.gameManager.IsFirstPersonView) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else {
            CinemachineFreeLook freeLookCamera =
                personCameraController.GetPersonController().mPlayerCamera as CinemachineFreeLook;
            freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0f; 
        }
        this.DisplayBulletin(true);
    }

    protected override void DeactiveAction() {
        if (this.bulletinPrefab.activeSelf) {
            if (this.is3DObject) {
                this.mainCamera.gameObject.SetActive(true);
            }
            if (!this.isVoiceCheck) {
                base.DeactiveAction();
            }
            this.DisplayBulletin(false);
            this.gameManager.MuteFootsteps(false);
            if (this.gameManager.IsFirstPersonView) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                PersonCameraController personCameraController = GameObject.FindObjectOfType<PersonCameraController>();
                CinemachineFreeLook freeLookCamera = personCameraController.GetPersonController().mPlayerCamera as CinemachineFreeLook;
                freeLookCamera.m_XAxis.m_MaxSpeed = 900f;
                freeLookCamera.m_YAxis.m_MaxSpeed = 20f; 
            }
            StartCoroutine(this.DisableBusyStatus());
        }
    }

    private IEnumerator DisableBusyStatus() {
        yield return new WaitForSeconds(0.2f);
        GameObject.FindObjectOfType<GameManager>().IsBusy = false;
    }
}
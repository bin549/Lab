using System.Collections;
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
 
    protected override void Awake() {
        base.Awake();
        this.mainCamera = Camera.main;
    }

    protected override void Update() {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape) && base.isInteracting) {
            this.DeactiveAction();
        }
    }

    public void DisplayBulletin(bool isDisplay) {
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindObjectOfType<GameManager>().IsBusy = true;
        GameObject.FindObjectOfType<PersonCameraController>().GetPersonController().mPlayerCamera.gameObject
            .SetActive(false);
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            this.DisplayBulletin(false);
            GameObject.FindObjectOfType<PersonCameraController>().GetPersonController().mPlayerCamera.gameObject
                .SetActive(true);
            StartCoroutine(this.DisableBusyStatus());
        }
    }

    private IEnumerator DisableBusyStatus() {
        yield return new WaitForSeconds(0.2f);
        GameObject.FindObjectOfType<GameManager>().IsBusy = false;
    }
}
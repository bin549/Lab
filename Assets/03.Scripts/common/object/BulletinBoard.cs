using System.Collections;
using UnityEngine;

public class BulletinBoard : InteractableItem {
    [SerializeField] private GameObject bulletinPrefab;

    public GameObject BulletinPrefab => bulletinPrefab;

    [SerializeField] private bool isVoiceCheck = false;

    protected override void Awake() {
        base.Awake();
    }

    protected override void Update() {
        base.Update();
    }

    public void DisplayBulletin(bool isDisplay) {
        this.bulletinPrefab.SetActive(isDisplay);
    }

    protected override void InteractAction() {
        GameObject.FindObjectOfType<PlayerAnimate>().UpdateSpeed(0f);
        if (!this.bulletinPrefab.activeSelf) {
            if (this.isVoiceCheck) {
                base.InteractAction();
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindObjectOfType<GameManager>().IsBusy = true;
            GameObject.FindObjectOfType<PersonCameraController>().GetPersonController().mPlayerCamera.gameObject
                .SetActive(false);
            this.DisplayBulletin(true);
        } else {
            this.DeactiveAction();
        }
    }

    protected override void DeactiveAction() {
        if (this.bulletinPrefab.activeSelf) {
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
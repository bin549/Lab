using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDetector : MonoBehaviour {
    public float distanceOpen = 5;
    [SerializeField] private InteractableObject interactableObject = null;

    private void Update() {
        if (this.interactableObject) {
            this.interactableObject.OnHintToggle(false);
        }
    }

    private void LateUpdate() {
        this.DetectObject();
    }

    private void DetectObject() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, this.distanceOpen)) {
            if (hit.transform.GetComponent<InteractableObject>()) {
                this.interactableObject = hit.transform.GetComponent<InteractableObject>();
                this.interactableObject.OnHintToggle(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    if (hit.transform.GetComponent<BulletinBoard>()) {
                        BulletinBoard bulletinBoard = hit.transform.GetComponent<BulletinBoard>();
                        bulletinBoard.DisplayBulletin(true);
                    } else if (hit.transform.GetComponent<Door>()) {
                        Door door = hit.transform.GetComponent<Door>();
                        GameObject.FindObjectOfType<DoorHandler>().ChangeScene(door);
                    }
                }
            }
        }
    }
}

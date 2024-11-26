using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class BulletinBoard : MonoBehaviour {
    private InteractableObject interactableObject;
    [SerializeField] private GameObject bulletinPrefab;

    private void Awake() {
        this.interactableObject = GetComponent<InteractableObject>();
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.interactableObject.IsInteractable()) {
            this.DisplayBulletin(true);
        }
        if (this.bulletinPrefab.activeSelf && Input.GetKeyDown(KeyCode.Escape)) {
            this.DisplayBulletin(false);
        }
    }

    public void DisplayBulletin(bool isDisplay) {
        this.bulletinPrefab.SetActive(isDisplay);
    }
}
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class BulletinBoard : MonoBehaviour {
    private InteractableObject interactableObject;

    private void Awake() {
        this.interactableObject = GetComponent<InteractableObject>();
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.interactableObject.IsInteractable()) {
            Destroy(this.gameObject);
        }
    }
}
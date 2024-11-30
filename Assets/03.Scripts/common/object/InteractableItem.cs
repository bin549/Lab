using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class InteractableItem : MonoBehaviour {
    [HideInInspector] protected InteractableObject interactableObject;
    private Monologue monologue;
    [SerializeField] private MonologueClip[] monologues;
    private bool isInteracting = false;

    protected virtual void Awake() {
        this.interactableObject = GetComponent<InteractableObject>();
        this.monologue = FindObjectOfType<Monologue>();
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.interactableObject.IsInteractable()) {
            this.InteractAction();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && this.isInteracting) {
            this.DeactiveAction();
        }
    }

    protected virtual void InteractAction() {
        this.isInteracting = true;
        if (this.monologues.Length != 0) {
            MonologueClip monologueClip = this.monologues[0];
            this.monologue.Play(monologueClip);
        }
        this.isInteracting = false;
    }

    protected virtual void DeactiveAction() {
        this.isInteracting = false;
        if (this.monologues.Length != 0) {
            MonologueClip monologueClip = this.monologues[0];
            this.monologue.Play(monologueClip);
        }
    }
}
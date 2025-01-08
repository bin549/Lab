using TMPro;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class InteractableObject : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI originText, detectedText;
    private LineRenderer lineRenderer;
    [SerializeField] private Transform lineStartPoint;
    [SerializeField] private Transform lineEndPoint;
    public TextMeshProUGUI DetectedText => detectedText;
    [SerializeField] private Outline outline;

    private void Awake() {
        this.lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void Start() {
        this.originText.gameObject.SetActive(true);
        this.detectedText.gameObject.SetActive(false);
        if (this.outline) { 
            this.outline.enabled = false;
        }
        this.InitDashedLine();
    }

    private void InitDashedLine() {
        this.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        this.lineRenderer.startWidth = 0.007f;
        this.lineRenderer.endWidth = 0.007f;
        this.lineRenderer.positionCount = 2;
        this.lineRenderer.SetPosition(0, lineStartPoint.position);
        this.lineRenderer.SetPosition(1, lineEndPoint.position);
    }

    public bool IsInteractable() {
        return this.detectedText.gameObject.activeSelf; 
    }

    public void OnHintToggle(bool isToggle) {
        this.originText.gameObject.SetActive(!isToggle);
        this.detectedText.gameObject.SetActive(isToggle);
        this.outline.enabled = isToggle;
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.OnHintToggle(true);
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.OnHintToggle(false);
        }
    }
}
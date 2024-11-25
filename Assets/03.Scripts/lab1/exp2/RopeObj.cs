using UnityEngine;

public class RopeObj : MonoBehaviour {
    public LineRenderer lineRenderer;
    public Transform fixedPulley;

    private void Start() {
        this.lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        this.lineRenderer.SetPosition(0, transform.position);
        this.lineRenderer.SetPosition(1, fixedPulley.transform.position);
    }
}
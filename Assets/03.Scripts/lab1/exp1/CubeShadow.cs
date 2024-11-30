using UnityEngine;

public class CubeShadow : MonoBehaviour {
    [SerializeField] private GameObject cubeShadowPiece;
    [SerializeField] private bool isFocus;
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform target;

    private void OnEnable() {
        this.cubeShadowPiece.SetActive(false);
        this.isFocus = false;
    }

    private void OnMouseEnter() {
        this.cubeShadowPiece.SetActive(true);
        this.isFocus = true;
    }

    private void OnMouseExit() {
        this.cubeShadowPiece.SetActive(false);
        this.isFocus = false;
    }

    private void OnMouseUp() {
        if (this.isFocus) {
            GetComponent<MeshRenderer>().enabled = false;
            this.cubeShadowPiece.SetActive(false);
            this.cube.SetActive(true);
            this.cube.GetComponent<MeshRenderer>().enabled = true;
            this.cube.transform.position = target.position;
        }
    }
}
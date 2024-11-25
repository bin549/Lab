using UnityEngine;

public class DestoryRopeByPosition : MonoBehaviour {
    private Vector3 position;
    public GameObject target;

    private void Start() {
        position = target.GetComponent<RecordRopeInitDestoryPosition>().getPosition();
    }

    private void FixedUpdate() {
        if (this.transform.position.x < position.x) {
            Destroy(gameObject);
        }
    }
}
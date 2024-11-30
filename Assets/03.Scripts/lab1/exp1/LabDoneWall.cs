using System.Collections;
using UnityEngine;

public class LabDoneWall : MonoBehaviour {
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform resetPoint;
    [SerializeField] private LabDetector labDetector;

    private void OnTriggerEnter(Collider collision) {
        StartCoroutine(this.ResetLab());
    }

    private IEnumerator ResetLab() {
        yield return new WaitForSeconds(1.4f);
        cube.transform.position = resetPoint.position;
        this.labDetector.ExitLab(true);
    }
}
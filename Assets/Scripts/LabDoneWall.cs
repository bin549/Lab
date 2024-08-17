using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoneWall : MonoBehaviour {
    [SerializeField] private LabOne labOne;
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform resetPoint;
    [SerializeField] private LabDetector labDetector;

    private void Awake() { 
        this.labOne = FindObjectOfType<LabOne>();
    }


    private void OnTriggerEnter(Collider collision) {
        this.labOne.PassLab();
        StartCoroutine(this.ResetLab());
    }

    private IEnumerator ResetLab() {
        yield return new WaitForSeconds(1.4f);
        cube.transform.position = resetPoint.position;
        this.labDetector.ExitLab(true);
    }
}
 
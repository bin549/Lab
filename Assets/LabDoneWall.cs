using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoneWall : MonoBehaviour {
    [SerializeField] private LabOne labOne;

    private void Awake() {
        this.labOne = FindObjectOfType<LabOne>();
    }


    private void OnTriggerEnter(Collider collision) {
        this.labOne.PassLab();
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hezi : MonoBehaviour {
    private Rigidbody rigidbody;
    public float hezispeed;
    [SerializeField] private LabDetector labDetector;
    [SerializeField] private Transform resetPoint;
    [SerializeField] private Transform xcResetPoint;
    [SerializeField] private xiaoche xc;
    [SerializeField] private LabOne labOne;
    
    private void Awake() { 
        this.labOne = FindObjectOfType<LabOne>();
    }

    private void Start() {
        this.rigidbody = GetComponent<Rigidbody>();
    } 

    private void OnMouseDown(){
        this.rigidbody.useGravity = true;
        this.labOne.PassLab();
        StartCoroutine(this.ResetLab());
    }

    private IEnumerator ResetLab() {
        yield return new WaitForSeconds(1.4f);
        this.rigidbody.useGravity = false;
        this.transform.position = this.resetPoint.position;
        this.xc.transform.position = this.xcResetPoint.position;
        this.labDetector.ExitLab(true);
    }

    private void FixedUpdate() {
        hezispeed = rigidbody.velocity.magnitude;
    }

    public void rigidbodyadd() {
        rigidbody.mass = rigidbody.mass + 1;

    }
    
    public void rigidbodyuse() {
        rigidbody.useGravity = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBox : MonoBehaviour {
    private Rigidbody rigidbody;
    public float boxSpeed;
    [SerializeField] private LabDetector labDetector;
    [SerializeField] private Transform resetPoint;
    [SerializeField] private Transform xcResetPoint;
    [SerializeField] private WeightCar weightCar;
    
    private void Start() {
        this.rigidbody = GetComponent<Rigidbody>();
    } 

    private void OnMouseDown(){
        this.rigidbody.useGravity = true;
        StartCoroutine(this.ResetLab());
    }

    private IEnumerator ResetLab() {
        yield return new WaitForSeconds(1.4f);
        this.rigidbody.useGravity = false;
        this.transform.position = this.resetPoint.position;
        this.weightCar.transform.position = this.xcResetPoint.position;
        this.labDetector.ExitLab(true);
    }

    private void FixedUpdate() {
        this.boxSpeed = this.rigidbody.velocity.magnitude;
    }

    public void rigidbodyadd() {
        this.rigidbody.mass = this.rigidbody.mass + 1;
    }
    
    public void rigidbodyuse() {
        this.rigidbody.useGravity = true;
    }
}

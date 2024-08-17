using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hezi : MonoBehaviour {
    private Rigidbody rigidbody;
    public float hezispeed;
    
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
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

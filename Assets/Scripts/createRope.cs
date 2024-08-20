using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRope : MonoBehaviour {
    private bool isCreate = true;
    private Vector3 initTransform;
    public Transform nextJoint;
    private Vector3 initNext;

    private void Start() {
        isCreate = true;
        initTransform = transform.position;
        initNext = nextJoint.position;
    }

    private void FixedUpdate() {
        if (transform.position.y < initNext.y && isCreate) {
            print("create");
            GameObject newJoint = Instantiate(gameObject);
            newJoint.transform.position = initTransform;
            newJoint.transform.parent = GameObject.FindWithTag("ropes").transform;
            isCreate = false;
        }
    }
}

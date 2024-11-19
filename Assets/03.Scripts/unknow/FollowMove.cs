using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMove : MonoBehaviour {
    Transform lastTransform;

    Vector3 move;

    void Start() {
        lastTransform = this.transform;
    }

    void FixedUpdate() {
        move = this.transform.position - lastTransform.position;
    }
}
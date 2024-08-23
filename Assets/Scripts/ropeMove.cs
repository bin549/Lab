using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeMove : MonoBehaviour {
    private Transform target;

    private Vector3 startPostion;

    void Start() {
        target = GameObject.FindWithTag("car").transform;
        startPostion = this.transform.position;
    }

    void FixedUpdate() {
        this.transform.position =
            startPostion + GameObject.FindWithTag("car").GetComponent<carMove>().Move;
    }
}

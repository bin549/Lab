﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightMove : MonoBehaviour {
    private Transform target;
    private Vector3 startPostion;

    private void Start() {
        target = GameObject.FindWithTag("car").transform;
        startPostion = this.transform.position;
    }

    private void FixedUpdate() {
        this.transform.position =
            startPostion + new Vector3(0, GameObject.FindWithTag("car").GetComponent<carMove>().Move.x, 0);
    }
}
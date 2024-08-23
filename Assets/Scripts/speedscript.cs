using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedscript : MonoBehaviour {
    public Rigidbody targetObj;
    public TextMesh inTimeSpeed;
    public TextMesh maxSpeed;
    public TextMesh aT;

    private double max = 0;
    private double min = 0;

    private double lastSpeed = 0;
    private double a = 0;

    private bool flag = true;

    private void FixedUpdate() {
        double speed = targetObj.velocity.magnitude;
        if (flag) {
            flag = false;
            a = 0;
            lastSpeed = speed;
        } else {
            a = (speed - lastSpeed) / 0.02;
            lastSpeed = speed;
        }
        aT.text = Math.Round(a, 2).ToString();
    }

    void Update() {
        double speed = targetObj.velocity.magnitude;
        speed = Math.Round(speed, 2);
        inTimeSpeed.text = speed.ToString();
        if (speed >= max)
            max = speed;
        maxSpeed.text = max.ToString();
    }
}

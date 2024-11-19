using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeed : MonoBehaviour {
    private Rigidbody rigidbody;
    private double speed;
    private double lastspeed = 0;
    private double a;
    private List<double> Accelerate;
    private bool flag = false;

    public double getSpeed() {
        return speed;
    }

    public double getA() {
        return a;
    }

    public void resetA() {
        a = 0;
    }

    private void Awake() {
        Accelerate = new List<double>();
    }

    void Start() {
        rigidbody = this.transform.GetComponent<Rigidbody>();
    }

    public List<double> getAccelerate() {
        return Accelerate;
    }

    private void FixedUpdate() {
        speed = rigidbody.velocity.magnitude;
        a = (speed - lastspeed) / 0.02;
        lastspeed = speed;
        if (a > 0) {
            Accelerate.Add(a);
        }
        showSpeed();
    }

    void showSpeed() {
    }

    void recordStatu() {
        Debug.Log(this.GetComponent<Transform>().position);
        Debug.Log("速度" + speed.ToString());
        // Debug.Log("加速度" + a.ToString());
        Debug.Log("质量" + rigidbody.mass);
        Debug.Log("重力" + Physics.gravity);
        //Debug.Log(this.GetComponent<BoxCollider>().material.);
        Debug.Log("摩擦系数：" + this.GetComponent<BoxCollider>().material.dynamicFriction);
        Debug.Log("摩擦系数结合方式：" + this.GetComponent<BoxCollider>().material.frictionCombine);
        Debug.Log("加速度" + a.ToString());
        Debug.Log("**********************************");
    }
}
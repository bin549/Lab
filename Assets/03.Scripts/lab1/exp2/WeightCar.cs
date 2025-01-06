using System;
using UnityEngine;

public class WeightCar : MonoBehaviour {
    public static WeightCar singleton;
    private Rigidbody rigid;
    public float speed = 0;
    public bool weightCarSpeedbool = false;
    private float xiaochespeed;
    private bool suduxianshibool = false;

    public WeightCar() {
        singleton = this;
    }

    private void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        DateTime NowTime = DateTime.Now.ToLocalTime();
        speed = GameObject.Find("m1").GetComponent<WeightBox>().boxSpeed;
        if (this.weightCarSpeedbool) {
            rigid.velocity = Vector3.forward * speed;
        }
        xiaochespeed = rigid.velocity.magnitude;
    }

    public void rigidbodyadd2() {
        rigid.mass = rigid.mass + 1;
        suduxianshibool = true;
    }

    public void kaishiyouxi() {
        weightCarSpeedbool = true;
    }
}
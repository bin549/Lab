using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI;

public class WeightCar : MonoBehaviour {
    public static WeightCar singleton;
    private Rigidbody rigid;
    public float speed = 0;
    public bool weightCarSpeedbool = false;
    private float xiaochespeed;
    private bool suduxianshibool = false;
    public float kg = 1;
    public float kh = 1;

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
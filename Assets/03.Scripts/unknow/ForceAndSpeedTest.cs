using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAndSpeedTest : MonoBehaviour {
	private Rigidbody rigidbody;
	private double speed;
	private double lastspeed=0;
	private double a;
	private bool flag = false;

	private void Start () {
		Debug.Log("开始位置"+this.GetComponent<Transform>().position);
		rigidbody= this.transform.GetComponent<Rigidbody>();
		//InvokeRepeating("recordStatu", 0f,1f);
	}

	private void FixedUpdate() {
		speed = rigidbody.velocity.magnitude;
		a = (speed - lastspeed) / 0.02;
		lastspeed = speed;
		Debug.Log("速度"+speed.ToString());
		Debug.Log("质量"+rigidbody.mass);
		Debug.Log(Physics.gravity);
		Debug.Log("加速度" + a.ToString());
	}

	private void recordStatu() {
		Debug.Log(this.GetComponent<Transform>().position);
		Debug.Log("速度"+speed.ToString());
		Debug.Log("质量"+rigidbody.mass);
		Debug.Log("重力"+Physics.gravity);
		Debug.Log("摩擦系数："+this.GetComponent<BoxCollider>().material.dynamicFriction);
		Debug.Log("摩擦系数结合方式："+this.GetComponent<BoxCollider>().material.frictionCombine);
		Debug.Log("加速度" + a.ToString());
		Debug.Log("**********************************");
	}
}

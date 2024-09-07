using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab3DownMove : MonoBehaviour {
	private Vector3 moveSpeed;
	private GameObject car;
	
	private bool isBegin;
	
	void Start () {
		car = GameObject.FindWithTag("car");
		isBegin = car.GetComponent<carMove>().getIsBegin();
	}
	
	void FixedUpdate () {
		moveSpeed = car.GetComponent<carMove>().getDownSpeed();
		Vector3 speed = new Vector3(0, moveSpeed.x, 0);
		if(GameObject.FindWithTag("car").GetComponent<carMove>().enabled) {
			transform.Translate(speed*0.02f);
		}
	}
}

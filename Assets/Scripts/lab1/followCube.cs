using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCube : MonoBehaviour {
	private Transform target;
	
	void Update () {
		if (GameObject.FindWithTag("Cube") != null)
		{
			target = GameObject.FindWithTag("Cube").transform;
		}
	}

	private void FixedUpdate()
	{
		transform.position=new Vector3(target.position.x-0.1f,target.position.y+0.1f,target.position.z);
	}
}

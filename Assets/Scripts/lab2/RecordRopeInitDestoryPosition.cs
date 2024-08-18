using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordRopeInitDestoryPosition : MonoBehaviour
{

	public Transform lastJointOfRope;

	private Vector3 position;

	private void Start () {
		position = lastJointOfRope.position;
	}
	
	public Vector3 getPosition() {
		return position;
	}
}

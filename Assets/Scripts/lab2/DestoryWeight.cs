using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWeight : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Weight"))
		{
			Destroy(other.gameObject);
		}
	}
}

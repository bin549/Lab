using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRope : MonoBehaviour {
	private void OnTriggerStay(Collider other)
	{
		if(other.tag.Equals("Rope")) {
			other.GetComponent<MeshRenderer>().enabled = false;
			
		}
	}

	private void OnTriggerExit(Collider other)
	{
		other.GetComponent<MeshRenderer>().enabled = true;
	}
}

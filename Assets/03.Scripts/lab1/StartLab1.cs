using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLab1 : MonoBehaviour {
	public void Begin() {
		GameObject Dsnap1 = GameObject.FindWithTag("DownSnap");
		GameObject Usnap = GameObject.FindWithTag("UpSnap");
		print("begin");
		if (Dsnap1!=null && Dsnap1.active) {
			GameObject cube = GameObject.FindWithTag("Cube");
			cube.GetComponent<Rigidbody>().isKinematic = false;
			//GameObject weight = GameObject.FindWithTag("Weight");
			//weight.GetComponent<Rigidbody>().isKinematic = false;
			cube.GetComponent<Rigidbody>().useGravity = true;
			//weight.GetComponent<Rigidbody>().useGravity = true;
		} else if ( Usnap!=null && Usnap.active ) {
			GameObject cube = GameObject.FindWithTag("Cube");
			cube.GetComponent<Rigidbody>().isKinematic = false;
			cube.GetComponent<Rigidbody>().useGravity = true;
		}
		else {
			print("777");
		}
		
	}
}

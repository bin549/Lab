using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightTrigger : MonoBehaviour {
	private bool WeightIn=false;
	private bool hasWeight = false;

	private void Awake() {
		WeightIn=false;
		hasWeight = false;
	}
	
	public void resetHasWeight() {
		hasWeight = false;
		WeightIn = false;
	}
	
	public void StartLab() {
		if (WeightIn) {
			hasWeight = true;
		}
	}

	public bool getHasWeight() {
		return hasWeight;
	}
	
	private void OnTriggerStay(Collider other) {
		
		if (other.gameObject.tag.Equals("Weight")) {
			WeightIn = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag.Equals("Weight")) {
			WeightIn = false;
		}
	}
}

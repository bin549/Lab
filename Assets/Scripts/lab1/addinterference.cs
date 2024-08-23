using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addinterference : MonoBehaviour {
	public GameObject target;
	public void OnClick(bool isOn) {
		if (isOn) {
			target.GetComponent<getRecord>().onInter();
		} else {
			target.GetComponent<getRecord>().offInter();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDynamicFriction : MonoBehaviour {
	public GameObject target;

	void Update () {
		//print(target.GetComponent<BoxCollider>().material.dynamicFriction);
		GetComponent<Text>().text = target.GetComponent<BoxCollider>().material.dynamicFriction.ToString();
	}
}

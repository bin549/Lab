using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panDuanFanZhuan : MonoBehaviour {
	public GameObject zhengfang;
	public GameObject daofang;
	public GameObject showData;
	public GameObject showTip;
	private bool flag = true;

	private void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Cube") || other.tag.Equals("CubeWaite")|| other.tag.Equals("CubeUnusing")) {
			if(GameObject.FindWithTag("Cube")) {
				GameObject.FindWithTag("Cube").tag = "CubeUnusing";
			}
			other.tag = "Cube";
			print("enter" + flag);
			showTip.SetActive(true);
			if (flag) {
				zhengfang.SetActive(true);
				daofang.SetActive(false);
				flag = false;
			} else {
				zhengfang.SetActive(false);
				daofang.SetActive(true);
				flag = true;
			}
			showData.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag.Equals("Cube") || other.tag.Equals("CubeWaite")|| other.tag.Equals("CubeUnusing")) {
			showTip.SetActive(false);
		}
	}
}

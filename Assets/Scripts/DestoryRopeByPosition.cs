using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestoryRopeByPosition : MonoBehaviour {
	//获取最后一个节点的位置，通过是否position的X大于这个位置来判断是否销毁该节点
	Vector3 position;
	//保存了最后一个节点初始位置的物体
	public GameObject target;
	
	void Start () {
		position = target.GetComponent<RecordRopeInitDestoryPosition>().getPosition();
	}
	
	void FixedUpdate () {
		if (this.transform.position.x < position.x)
		{
			//print("run"+this.name);
			Destroy(gameObject);
			//this.enabled = false;
		}
	}
}

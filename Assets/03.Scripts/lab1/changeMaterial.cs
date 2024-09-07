using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMaterial : MonoBehaviour {
	public Material other;
	public MeshRenderer meshRender; 
	public PhysicMaterial otherP;
	public MeshCollider meshCollider;
	
	private void Start() {
		this.GetComponent<Button>().onClick.AddListener(OnClick);
	}

	private void OnClick() {
		this.meshRender.material = other;
		this.meshCollider.material = otherP;
	}
}

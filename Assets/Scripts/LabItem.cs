using UnityEngine;
using System.Collections;

public class LabItem : MonoBehaviour {
	private bool isFocus = false;
    [SerializeField] private GameObject cubeShadow;
    [SerializeField] private LabOne labOne;

    public bool IsFocus {
        get {
            return this.isFocus;
        }
        set {
            this.isFocus = value;
        }
    }

    private void Update() {
    	if (this.IsFocus) {
    	}
    }

    private void OnMouseDown(){
    	this.IsFocus = true;
    	this.cubeShadow.SetActive(true);
    	GetComponent<MeshRenderer>().enabled = false;
    }


    private void OnMouseUp(){
    	if (!this.labOne.IsWork) {
	    	this.IsFocus = false;
	    	this.cubeShadow.SetActive(false);
	    	GetComponent<MeshRenderer>().enabled = true;
    	}
    }


    private void OnMouseEnter() {
    	GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit() {
    	GetComponent<Outline>().enabled = false;
    }
}

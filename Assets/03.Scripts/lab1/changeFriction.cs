using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class changeFriction : MonoBehaviour {
    private Slider slider;
    public GameObject target;
    public GameObject target2;

    private void Start() {
        this.slider = gameObject.GetComponent<Slider>();
        this.slider.onValueChanged.AddListener(SliderChange);
    }

    private void SliderChange(float t) {
        target.GetComponent<MeshCollider>().material.dynamicFriction = (float)Math.Round(t, 1);
        target2.GetComponent<BoxCollider>().material.dynamicFriction = (float)Math.Round(t, 1);
        GameObject.FindWithTag("ball").GetComponent<Rigidbody>().angularDrag = (float) Math.Round(t, 1);
    }
}

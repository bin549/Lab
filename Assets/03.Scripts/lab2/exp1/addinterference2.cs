﻿using UnityEngine;

public class addinterference2 : MonoBehaviour {
    public GameObject target;

    public void OnClick(bool isOn) {
        if (isOn) {
            target.GetComponent<getCarMove>().onInter();
        } else {
            target.GetComponent<getCarMove>().offInter();
        }
    }
}
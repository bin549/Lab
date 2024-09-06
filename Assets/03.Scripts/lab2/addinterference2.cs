using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addinterference2 : MonoBehaviour {
    public GameObject target;

    public void OnClick(bool isOn) {
        if (isOn) {
            //target.SetActive(true);
            target.GetComponent<getCarMove>().onInter();
        }
        else {
            target.GetComponent<getCarMove>().offInter();
            //target.SetActive(false);
        }
    }
}

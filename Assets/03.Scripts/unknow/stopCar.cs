using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCar : MonoBehaviour {
    public GameObject Stext;
    public AudioSource woodCollision;

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("car")) {
            other.GetComponent<carMove>().enabled = false;
            // other.GetComponent<Rigidbody>().velocity=Vector3.zero;
            // other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Stext.GetComponent<getCarMove>().updateRecord();
            woodCollision.Play();
        }
    }
}
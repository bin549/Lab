using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCollision : MonoBehaviour {
    private bool isStop = false;
    private Transform stopTransform;
    private Collision otherCollision;
    public AudioSource axe;
    public AudioSource wood;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Cube")) {
            if (this.GetComponent<AudioSource>().clip.name == "木头落地") {
                this.GetComponent<AudioSource>().Play();
            }
            GameObject.FindWithTag("recordText").SendMessage("updateText", getAc());
            GameObject.FindWithTag("Cube").GetComponent<GetSpeed>().resetA();
            other.gameObject.tag = "CubeUnusing";
        }
        if (other.gameObject.name.Equals("metalCube")) {
            axe.Play();
        }
        if (other.gameObject.name.Equals("wood")) {
            wood.Play();
        }
    }

    private double getAc() {
        List<double> ac = GameObject.FindWithTag("Cube").GetComponent<GetSpeed>().getAccelerate();
        double a = 0f;
        for (int i = 2; i < ac.Count - 2; i++) {
            if (Math.Abs(ac[i] - ac[i - 2]) < 0.1 && Math.Abs(ac[i] - ac[i + 2]) < 0.1) {
                a = ac[i];
            }
        }
        return Math.Round(a, 1, MidpointRounding.AwayFromZero);
    }
}

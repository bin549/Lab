using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour {
    int second;
    Vector3 MOVE;
    private Vector3 MoveSpeed;
    Vector3 startPostion;
    private bool isBegin = false;

    private double Ace;
    private double massOfCar;
    private double massOfWeights;

    private List<double> Slist;

    public double MassOfCar {
        get { return massOfCar; }
    }

    public double MassOfWeight {
        get { return massOfWeights; }
    }

    private void Awake() {
        Slist = new List<double>();
    }

    public void beginLab() {
        GetComponent<carMove>().enabled = true;
        isBegin = true;
    }

    public void restart() {
        second = 0;
        isBegin = false;
    }

    public Vector3 Move {
        get { return MOVE; }
    }

    public bool getIsBegin() {
        return isBegin;
    }

    void Start() {
        isBegin = false;
    }

    public Vector3 getDownSpeed() {
        return MoveSpeed;
    }

    private void FixedUpdate() {
        if (isBegin) {
            second += 1;
            MoveSpeed = speed(second);
            this.transform.Translate(MoveSpeed * 0.02f);
        }
    }

    private Vector3 speed(int s) {
        double carspeed;
        double massOfWeight = 0;
        if (GameObject.FindGameObjectsWithTag("dragWeight").Length > 0) {
            foreach (var g in GameObject.FindGameObjectsWithTag("dragWeight")) {
                massOfWeight += g.GetComponent<Rigidbody>().mass;
            }
        }

        massOfWeights = massOfWeight;
        double massOfCar = 0;
        if (GameObject.FindGameObjectsWithTag("carWeight").Length > 0) {
            foreach (var g in GameObject.FindGameObjectsWithTag("carWeight")) {
                massOfCar += g.GetComponent<Rigidbody>().mass;
            }
        }
        if (GameObject.FindWithTag("car") != null) {
            massOfCar += this.gameObject.GetComponent<Rigidbody>().mass;
        }
        this.massOfCar = massOfCar;
        double a = massOfWeight / (massOfWeight + massOfCar) * Math.Abs(Physics.gravity.y);
        Ace = a;
        carspeed = a * 0.02 * s;
        Slist.Add(a * Math.Pow((0.02f * s), 2.0f) / 2f);
        return new Vector3(-(float)carspeed, 0, 0);
    }

    public List<double> getSlist() {
        return Slist;
    }

    public void cleanSlist() {
        Slist.Clear();
    }

    public double getAce() {
        return Ace;
    }
}
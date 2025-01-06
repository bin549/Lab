using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetLab : MonoBehaviour {
    public GameObject car;
    public GameObject weights;
    public GameObject getNewRopeFormBeginButton;
    public GameObject tip1;
    public GameObject tip2;

    private Vector3 carP;
    private Vector3 weightP;
    private List<GameObject> usingWeight;

    private void Start() {
        carP = car.transform.position;
        weightP = weights.transform.position;
        usingWeight = new List<GameObject>();
    }

    public void resetThisLab() {
        car.GetComponent<carMove>().restart();
        if (GameObject.FindGameObjectsWithTag("carWeight").Length > 0) {
            foreach (var w in GameObject.FindGameObjectsWithTag("carWeight")) {
                usingWeight.Add(w);
            }
        }
        if (GameObject.FindGameObjectsWithTag("dragWeight").Length > 0) {
            foreach (var w in GameObject.FindGameObjectsWithTag("dragWeight")) {
                usingWeight.Add(w);
            }
        }
        if (usingWeight.Count > 0) {
            foreach (var VARIABLE in usingWeight) {
                Destroy(VARIABLE.gameObject);
            }
        }
        if (GameObject.FindWithTag("car").GetComponent<carMove>().getIsBegin()) {
            Destroy(GameObject.FindWithTag("oldRope"));
            GameObject newRope = getNewRopeFormBeginButton.GetComponent<begincarlab>().getNewRope();
            newRope.SetActive(true);
            newRope.tag = "oldRope";
        }
        tip1.SetActive(false);
        tip2.SetActive(false);
        car.transform.position = carP;
        weights.transform.position = weightP;
    }

    public void chongzhi() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

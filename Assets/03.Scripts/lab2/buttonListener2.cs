using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonListener2 : MonoBehaviour {
    private bool flag;

    public GameObject menu;

    void Start() {
        flag = true;
    }

    private void B1Pressed(object sender) {
        if (menu.activeSelf == false) {
            menu.SetActive(true);
            flag = false;
        } else {
            menu.SetActive(false);
            flag = true;
        }
    }
}

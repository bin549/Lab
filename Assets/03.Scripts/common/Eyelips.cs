using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyelips : MonoBehaviour {
    [SerializeField] private GameObject text;

    public void DisplayText() {
        this.text.SetActive(true);
    }

    public void HideText() {
        this.text.SetActive(false);
    }
}
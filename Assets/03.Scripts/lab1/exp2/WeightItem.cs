using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItem : MonoBehaviour {
    [SerializeField] private WeightCar weightCar;
    [SerializeField] private GameObject weightShadow;

    private void OnMouseDown() {
        this.weightShadow.SetActive(true);
        this.weightCar.weightCarSpeedbool = true;
        this.gameObject.SetActive(false);
    }
}
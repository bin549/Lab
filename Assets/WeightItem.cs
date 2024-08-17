using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItem : MonoBehaviour {
    [SerializeField] private xiaoche xc;
    [SerializeField] private GameObject weightShadow;

    private void OnMouseDown(){
        this.weightShadow.SetActive(true);
        this.xc.xiaochespeedbool = true;
        this.gameObject.SetActive(false);
    }
}

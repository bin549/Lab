using UnityEngine;
using UnityEngine.UI;

public class showWeightMass : MonoBehaviour {
    public Text text;

    private void LateUpdate() {
        if (GameObject.FindWithTag("Weight")) {
            text.text = GameObject.FindWithTag("Weight").GetComponent<Rigidbody>().mass.ToString() + "KG";
        }
    }
}
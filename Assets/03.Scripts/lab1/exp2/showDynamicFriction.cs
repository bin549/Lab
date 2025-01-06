using UnityEngine;
using UnityEngine.UI;

public class showDynamicFriction : MonoBehaviour {
    public GameObject target;

    private void Update() {
        GetComponent<Text>().text = target
            .GetComponent<BoxCollider>()
            .material.dynamicFriction.ToString();
    }
}
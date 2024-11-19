using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    static float minAngle = 0f;
    static float maxAngle = -180f;
    static Rotate thisSpeed0;

    private void Start() {
        thisSpeed0 = this;
    }

    public static void ShowSpeed(float speed, float min, float max) {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        thisSpeed0.transform.eulerAngles = new Vector3(0, 0, -ang * 49.9f);
    }
}
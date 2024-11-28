using UnityEngine;
using System.Collections;

public class RecordPlayer : MonoBehaviour {
    private bool recordPlayerActive = false;
    GameObject disc;
    GameObject arm;
    int mode;
    float armAngle;
    float discAngle;
    float discSpeed;

    public bool RecordPlayerActive {
        get => recordPlayerActive;
        set => recordPlayerActive = value;
    }

    private void Awake() {
        disc = gameObject.transform.Find("teller").gameObject;
        arm = gameObject.transform.Find("arm").gameObject;
    }

    private void Start() {
        mode = 0;
        armAngle = 0.0f;
        discAngle = 0.0f;
        discSpeed = 0.0f;
    }

    private void Update() {
        if (mode == 0) {
            if (recordPlayerActive)
                mode = 1;
        } else if (mode == 1) {
            if (recordPlayerActive) {
                armAngle += Time.deltaTime * 30.0f;
                if (armAngle >= 30.0f) {
                    armAngle = 30.0f;
                    mode = 2;
                }
                discAngle += Time.deltaTime * discSpeed;
                discSpeed += Time.deltaTime * 80.0f;
            } else
                mode = 3;
        } else if (mode == 2) {
            if (recordPlayerActive)
                discAngle += Time.deltaTime * discSpeed;
            else
                mode = 3;
        } else {
            if (recordPlayerActive == false) {
                armAngle -= Time.deltaTime * 30.0f;
                if (armAngle <= 0.0f)
                    armAngle = 0.0f;
                discAngle += Time.deltaTime * discSpeed;
                discSpeed -= Time.deltaTime * 80.0f;
                if (discSpeed <= 0.0f)
                    discSpeed = 0.0f;
                if ((discSpeed == 0.0f) && (armAngle == 0.0f))
                    mode = 0;
            } else
                mode = 1;
        }
        arm.transform.localEulerAngles = new Vector3(0.0f, armAngle, 0.0f);
        disc.transform.localEulerAngles = new Vector3(0.0f, discAngle, 0.0f);
    }
}
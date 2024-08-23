using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRope : MonoBehaviour {
    private void OnTriggerStay(Collider other) {
        other.GetComponent<MeshRenderer>().enabled = true;
    }
}

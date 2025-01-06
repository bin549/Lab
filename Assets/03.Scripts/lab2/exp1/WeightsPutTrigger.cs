using UnityEngine;

public class WeightsPutTrigger : MonoBehaviour {
	public GameObject tip;

	private void OnTriggerStay(Collider other) {
		if (other.tag.Equals("Weight")) {
			tip.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag.Equals("Weight") || other.tag.Equals("carWeight")) {
			tip.SetActive(false);
		}	
	}
}


using UnityEngine;

public class DoorHandler : MonoBehaviour
{
	public GameObject text;
	public float DistanceOpen=3;

    private void Update()
    {
        this.DetectDoor();
    }

    private void DetectDoor()
    {
    	RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)) {
			if (hit.transform.GetComponent<Door>()) 
			{
				text.SetActive (true);
				if (Input.GetKeyDown(KeyCode.E))
				{
					hit.transform.GetComponent<Door>().OpenDoor();
				}
			} 
			else{
				text.SetActive (false);
			}
		} 
		else
		{
			text.SetActive (false);
		}
	}
}

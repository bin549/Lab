
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
	public GameObject text;
	public float DistanceOpen=5;
	[SerializeField] private Transform teleportDoor;
	[SerializeField] private TeleportCamera teleportCamera;
	[SerializeField] private Camera mCamera;
	private bool isTeleport = false;

	private void Awake () {
		this.mCamera = GetComponentInChildren<Camera>();
	}

    private void Update()
    {
        this.DetectDoor();
    }

    private void DetectDoor()
    {
    	if (this.isTeleport) {
    		return;
    	}
		text.SetActive(false);
    	RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen)) {
			if (hit.transform.GetComponent<Door>()) 
			{
				text.SetActive(true);
				if (Input.GetKeyDown(KeyCode.E))
				{
					this.isTeleport = true;
					this.text.SetActive(false);
					this.mCamera.gameObject.SetActive(false);
					this.teleportCamera.gameObject.SetActive(true);
					Door door = hit.transform.GetComponent<Door>();
					door.Teleport(teleportDoor);
					this.teleportCamera.SetupDoor(door);
				}
			} 
		} 
	}
}

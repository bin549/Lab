using UnityEngine;

public class DoorHandler : MonoBehaviour {
    [SerializeField] private Transform teleportDoor;
    [SerializeField] private TeleportCamera teleportCamera;
    [SerializeField] private bool isTeleport = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject skyBoxObj;
    [SerializeField] private PersonCameraController personCameraController;
    
    private void Awake() {
        this.personCameraController = GameObject.FindObjectOfType<PersonCameraController>();
    }

    private void Start() {
        this.teleportCamera.gameObject.SetActive(false);
    }

    public void ChangeScene(Door door) {
        this.isTeleport = true;
        this.personCameraController.HideCamera();
        this.skyBoxObj.gameObject.SetActive(false);
        this.teleportCamera.gameObject.SetActive(true);
        door.Teleport(teleportDoor);
        this.teleportCamera.SetupDoor(door);
    }
}
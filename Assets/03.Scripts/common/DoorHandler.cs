using UnityEngine;

public class DoorHandler : MonoBehaviour {
    public float distanceOpen = 5;
    [SerializeField] private Transform teleportDoor;
    [SerializeField] private TeleportCamera teleportCamera;
    [SerializeField] private bool isTeleport = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject skyBoxObj;
    [SerializeField] private Door door = null;
    [SerializeField] private PersonCameraController personCameraController;
    
    private void Awake() {
        this.personCameraController = GameObject.FindObjectOfType<PersonCameraController>();
    }

    private void Start() {
        this.teleportCamera.gameObject.SetActive(false);
    }

    private void Update() {
        if (this.door) {
            this.door.OnHintToggle(false);
        }
    }
    
    private void LateUpdate() {
        this.DetectDoor();
    }

    private void DetectDoor() {
        if (this.isTeleport) {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, this.distanceOpen)) {
            if (hit.transform.GetComponent<Door>()) {
                this.door = hit.transform.GetComponent<Door>();
                this.door.OnHintToggle(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    this.ChangeScene(door);
                }
            }
        }
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
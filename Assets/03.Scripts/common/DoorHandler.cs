using UnityEngine;

public class DoorHandler : MonoBehaviour {
    public float distanceOpen = 5;
    [SerializeField] private Transform teleportDoor;
    [SerializeField] private TeleportCamera teleportCamera;
    [SerializeField] private Camera mCamera;
    [SerializeField] private bool isTeleport = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject skyBoxObj;
    [SerializeField] private Door door = null;
        
    private void Awake() {
        this.mCamera = FindObjectOfType<Camera>();
    }

    private void Start() {
        this.teleportCamera.gameObject.SetActive(false);
    }

    private void Update() {
        if (this.door) {
            door.OnHintToggle(false);
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceOpen)) {
            if (hit.transform.GetComponent<Door>()) {
                door = hit.transform.GetComponent<Door>();
                door.OnHintToggle(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    this.ChangeScene(door);
                }
            }
        }
    }

    public void ChangeScene(Door door) {
        this.isTeleport = true;
        this.mCamera.gameObject.SetActive(false);
        this.skyBoxObj.gameObject.SetActive(false);
        this.teleportCamera.gameObject.SetActive(true);
        door.Teleport(teleportDoor);
        this.teleportCamera.SetupDoor(door);
    }
}
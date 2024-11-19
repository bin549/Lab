using UnityEngine;

public class DoorHandler : MonoBehaviour {
    public GameObject text;
    public float DistanceOpen = 5;
    [SerializeField] private Transform teleportDoor;
    [SerializeField] private TeleportCamera teleportCamera;
    [SerializeField] private Camera mCamera;
    private bool isTeleport = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject skyBoxObj;
    [SerializeField] private GameObject mUiBorder;

    private void Awake() {
        this.mCamera = GetComponentInChildren<Camera>();
    }

    private void Start() {
        this.teleportCamera.gameObject.SetActive(false);
    }

    private void Update() {
        this.DetectDoor();
    }

    private void DetectDoor() {
        if (this.isTeleport) {
            return;
        }
        this.text.SetActive(false);
        this.mUiBorder.SetActive(false);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen)) {
            if (hit.transform.GetComponent<Door>()) {
                this.text.SetActive(true);
                this.mUiBorder.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    this.isTeleport = true;
                    this.text.SetActive(false);
                    this.mUiBorder.SetActive(false);
                    this.mCamera.gameObject.SetActive(false);
                    this.skyBoxObj.gameObject.SetActive(false);
                    this.teleportCamera.gameObject.SetActive(true);
                    Door door = hit.transform.GetComponent<Door>();
                    this.audioManager.Stop();
                    door.Teleport(teleportDoor);
                    this.teleportCamera.SetupDoor(door);
                }
            }
        }
    }
}
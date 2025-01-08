using UnityEngine;

public class DoorHandler : MonoBehaviour {
    private Transform teleportDoor;
    [SerializeField] private TeleportCamera teleportCamera;
    [SerializeField] private bool isTeleport = false;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject skyBoxObj;
    private PersonCameraController personCameraController;

    private void Awake() {
        this.personCameraController = GameObject.FindObjectOfType<PersonCameraController>();
    }

    private void Start() {
        this.teleportCamera.gameObject.SetActive(false);
    }

    public void ChangeScene(Door door) {
        this.isTeleport = true;
        this.personCameraController.HideCamera();
        SoundRecorder soundRecorder = FindObjectOfType<SoundRecorder>(true);
        if (soundRecorder) {
            soundRecorder.MutePlayer(true);
        }
        Gramophone gramophone = FindObjectOfType<Gramophone>(true);
        if (gramophone) {
            gramophone.MutePlayer(true);
        }

        if (this.skyBoxObj) {
            this.skyBoxObj.gameObject.SetActive(false);
        }
        this.teleportCamera.gameObject.SetActive(true);
        door.Teleport(teleportDoor);
        this.teleportCamera.SetupDoor(door);
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(InteractableObject))]
public class Door : InteractableItem {
    public float smooth = 1.0f;
    [HideInInspector] public AudioSource audioSource;
    public AudioClip openDoorClip, closeDoorClip;
    [SerializeField] private GameObject doorMirror;
    private Animator doorMirrorAnimator;
    [SerializeField] private string labScene = "";
    private DoorHandler doorHandler;
    [SerializeField] private int playerLocationIndex = 0;

    protected override void Awake() {
        base.Awake();
        this.audioSource = gameObject.GetComponent<AudioSource>();
        this.doorMirrorAnimator = this.doorMirror.GetComponent<Animator>();
        this.doorHandler = GameObject.FindObjectOfType<DoorHandler>();
    }

    protected override void Update() {
        base.Update();
    }

    protected override void InteractAction() {
        if (this.labScene.Equals("start")) {
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.IsInLobby = true;
            gameManager.PlayerLobbyState = this.playerLocationIndex;
        }
        this.doorHandler.ChangeScene(this);
    }

    public void Teleport(Transform teleportDoor) {
        this.doorMirror.SetActive(true);
    }

    public void OpenDoor() {
        this.doorMirrorAnimator.SetTrigger("open");
        this.audioSource.clip = openDoorClip;
        this.audioSource.Play();
    }

    public void CloseDoor() {
        this.audioSource.clip = closeDoorClip;
        this.audioSource.Play();
        StartCoroutine(this.LoadLab(this.labScene));
    }

    private IEnumerator LoadLab(string sceneName) {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour {
    public float smooth = 1.0f; 
    public AudioSource audioSource;
    public AudioClip openDoorClip, closeDoorClip;
    [SerializeField] private GameObject doorMirror;
    [SerializeField] private Animator doorMirrorAnimator;
    [SerializeField] private string labScene = "";
    [SerializeField] private GameObject originText, detectedText;
    [SerializeField] private DoorHandler doorHandler;

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
        this.doorMirrorAnimator = doorMirror.GetComponent<Animator>();
    }
    
    private void Start() {
        this.doorMirror.SetActive(false);
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.detectedText.activeSelf) {
            this.doorHandler.ChangeScene(this);
        }
    }
    
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.originText.SetActive(false);
            this.detectedText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.originText.SetActive(true);
            this.detectedText.SetActive(false);
        }
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
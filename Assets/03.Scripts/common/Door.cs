using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(InteractableObject))]
public class Door : MonoBehaviour {
    public float smooth = 1.0f;
    public AudioSource audioSource;
    public AudioClip openDoorClip, closeDoorClip;
    [SerializeField] private GameObject doorMirror;
    [SerializeField] private Animator doorMirrorAnimator;
    [SerializeField] private string labScene = "";
    [SerializeField] private DoorHandler doorHandler;
    [SerializeField] private InteractableObject interactableObject;
    
    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
        this.doorMirrorAnimator = doorMirror.GetComponent<Animator>();
        this.interactableObject = gameObject.GetComponent<InteractableObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && this.interactableObject.IsInteractable()) {
            this.doorHandler.ChangeScene(this);
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
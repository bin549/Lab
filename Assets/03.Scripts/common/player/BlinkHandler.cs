using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkHandler : MonoBehaviour {
    [SerializeField] private Animator animator;
    private GameManager gameManager;
    [SerializeField] private bool isOpen = true;
    public int doorNum = 400;

    private void Awake() {
        animator.gameObject.SetActive(true);
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update() {
        if (this.gameManager.IsBusy) {
            return;
        }
        this.BlinkHandle();
        this.SceneHandle();
    }

    private void BlinkHandle() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.isOpen = !this.isOpen;
            this.animator.SetBool("isOpen", this.isOpen);
        }
    }

    private void SceneHandle() {
        if (Input.GetKeyDown(KeyCode.Backspace) && !this.isOpen) {
            if (SceneManager.GetActiveScene().name != LabsTag.START_SCENE) {
                StartCoroutine(this.SceneBack(LabsTag.START_SCENE));
            } else {
                this.QuitApp();
            }
        }
    }

    private IEnumerator SceneBack(string sceneName) {
        yield return new WaitForSeconds(0.0f);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
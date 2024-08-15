using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private bool isBusy = false;

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool IsBusy {
        get {
            return this.isBusy;
        }
        set {
            isBusy = value;
        }
    }

    private void Start() {
        this.audioManager.Play();
    }
}
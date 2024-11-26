using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private bool isBusy = false;
    [SerializeField] private int currentDoor01 = 0;
    [SerializeField] [Range(0, 10)] private int totalDoor01 = 3;
    [SerializeField] private int currentDoor02 = 0;
    [SerializeField] [Range(0, 10)] private int totalDoor02 = 1;
    [SerializeField] private int currentDoor03 = 0;
    [SerializeField] [Range(0, 10)] private int totalDoor03 = 2;
    [SerializeField] private bool isFirstPersonView = true;

    public bool IsFirstPersonView {
        get => isFirstPersonView;
        set => isFirstPersonView = value;
    }
    
    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public bool IsBusy {
        get { return this.isBusy; }
        set { isBusy = value; }
    }

    public int GetCurrentCount(int doorNum) {
        var currentCount = 0;
        switch (doorNum) {
            case 1:
                return this.currentDoor01;
            case 2:
                return this.currentDoor02;
            default:
                return this.currentDoor03;
        }
    }

    public int GetTotalCount(int doorNum) {
        var totalCount = 0;
        switch (doorNum) {
            case 1:
                return this.totalDoor01;
            case 2:
                return this.totalDoor02;
            default:
                return this.totalDoor03;
        }
    }

    public void IncreaseCount(int doorNum) {
        switch (doorNum) {
            case 1:
                currentDoor01++;
                break;
            case 2:
                currentDoor02++;
                break;
            case 3:
                currentDoor03++;
                break;
            default:
                break;
        }
    }
}
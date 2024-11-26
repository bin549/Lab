using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Door01UI : MonoBehaviour {
    [SerializeField] private GameManager gameManager;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void Start() {
        this.UpdateUI();
    }

    public void UpdateUI() {
        int num = this.GetSceneNum();
    }

    public void PassLab() {
        int num = this.GetSceneNum();
        this.gameManager.IncreaseCount(num);
        this.UpdateUI();
    }

    private int GetSceneNum() {
        int num = 1;
        switch (SceneManager.GetActiveScene().name) {
            case LabsTag.CHEMISTRY_SCENE:
                num = 1;
                return num;
            case LabsTag.Laboratory_SCENE:
                num = 2;
                return num;
            case LabsTag.BlackSpace_SCENE:
                num = 3;
                return num;
        }
        return num;
    }
}
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour {
    [SerializeField] private GameManager gameManager;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class UIManager : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI room01Text;
    [SerializeField] private TextMeshProUGUI room02Text;
    [SerializeField] private TextMeshProUGUI room03Text;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void Start() {
        this.UpdateUI();
    }

    private void UpdateUI() {
        this.room01Text.text = "(" + this.gameManager.GetCurrentCount(1).ToString() + "/" +
                               this.gameManager.GetTotalCount(1).ToString() + ")";
        this.room02Text.text = "(" + this.gameManager.GetCurrentCount(2).ToString() + "/" +
                               this.gameManager.GetTotalCount(2).ToString() + ")";
        this.room03Text.text = "(" + this.gameManager.GetCurrentCount(3).ToString() + "/" +
                               this.gameManager.GetTotalCount(3).ToString() + ")";
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class Door02UI : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI room01Text; 

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void Start() {
    	this.UpdateUI();
    }

    public void UpdateUI() {
        this.room01Text.text = this.gameManager.GetCurrentCount(2).ToString()+ "/"+ this.gameManager.GetTotalCount(2).ToString();
    }
    
    public void PassLab() {
        this.gameManager.IncreaseCount(2);
        this.UpdateUI();
    }
} 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class Door01UI : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI room01Text; 

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }


    private void Start() {
    	this.UpdateUI();
    }

    public void UpdateUI() {
        this.room01Text.text = this.gameManager.GetCurrentCount(1).ToString()+ "/"+ this.gameManager.GetTotalCount(1).ToString();
    }
    
    public void PassLab() {
        this.gameManager.IncreaseCount(1);
        this.UpdateUI();
    }
} 

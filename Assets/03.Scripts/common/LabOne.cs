using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabOne : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI introductionText;
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private Door01UI door01UI;
    [SerializeField] private string title = "斜面上静摩擦和动摩擦";
    [SerializeField] private string introduction = "这是一个模拟箱子被绳子拉着沿着水平面移动的过程。学生可以通过模拟来探索静摩擦和动摩擦的影响，以及它们与表面法向力的关系。";
    [SerializeField] private string tutorial = "第一步，第二步，第三步";
    [SerializeField] private bool isFinishied = false;

    public bool isWork;
    public bool isDone;

    public bool IsWork {
        get { return this.isWork; }
        set { this.isWork = value; }
    }

    public bool IsDone {
        get { return this.isDone; }
        set { this.isDone = value; }
    }

    private void Awake() {
        this.door01UI = FindObjectOfType<Door01UI>();
    }

    private void Start() {
        this.titleText.text = this.title;
        this.introductionText.text = this.introduction;
        // this.tutorialText.text = this.tutorial;
    }

    public void PassLab() {
        this.door01UI.PassLab();
        this.isFinishied = true;
    }
}
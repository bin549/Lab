using UnityEngine;
using TMPro;

public class LabOne : MonoBehaviour {
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
    
    public void PassLab() {
        this.isFinishied = true;
    }
}
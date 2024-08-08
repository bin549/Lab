using UnityEngine;
using Cinemachine;

public class LabItem : MonoBehaviour
{
    private bool mValid = true;
    private bool mFocused = false;
    private PlayerController mControllerRef = null;
    [SerializeField] private GameObject labUI;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        this.virtualCamera.gameObject.SetActive(false);
    }

    public void Focus(PlayerController controller)
    {
        if (!this.mValid || this.mFocused) 
        {
            return;
        }
        this.mControllerRef = controller;
        this.mControllerRef.SetInputEnabled(false); 
        this.labUI.SetActive(true);
        this.virtualCamera.gameObject.SetActive(true);
        this.ResetPuzzle();
        this.mFocused = true;
    }
    
    public void ResetPuzzle()
    {
        Debug.Log("play me");
    }
}

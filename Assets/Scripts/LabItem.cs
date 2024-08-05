using UnityEngine;

public class LabItem : MonoBehaviour
{
    private bool mValid = true;
    private bool mFocused = false;
    private PlayerController mControllerRef = null;
    [SerializeField] private GameObject labUI;

    public void Focus(PlayerController controller)
    {
        if (!this.mValid || this.mFocused) 
        {
            return;
        }
        mControllerRef = controller;
        mControllerRef.SetInputEnabled(false); 
        labUI.SetActive(true);
        this.ResetPuzzle();
        mFocused = true;
    }
    
    public void ResetPuzzle()
    {
        Debug.Log("play me");
    }
}

using UnityEngine;
using Cinemachine;
using System.Collections;

public class LabItem : MonoBehaviour
{
    private bool mValid = true;
    private bool mFocused = false;
    private PlayerController mControllerRef = null;
    [SerializeField] private GameObject labUI;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        this.virtualCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.UnFocusHandle();
    }

    public void Focus(PlayerController controller)
    {
        if (!this.mValid || this.mFocused) 
        {
            return;
        }
        this.gameManager.IsBusy = true;
        this.mControllerRef = controller;
        this.mControllerRef.SetInputEnabled(false); 
        this.labUI.SetActive(true);
        this.virtualCamera.gameObject.SetActive(true);
        this.ResetPuzzle();
        this.mFocused = true;
    }


    public void UnFocusHandle()
    {
        if (!this.gameManager.IsBusy)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.labUI.SetActive(false);
            this.virtualCamera.gameObject.SetActive(false);
            this.mControllerRef.SetInputEnabled(true); 
            StartCoroutine(this.DisableBusy());
            this.mFocused = false;
        }
    }
    
    private IEnumerator DisableBusy()
    {
        yield return new WaitForSeconds(.4f);
        this.gameManager.IsBusy = false;
    }

    public void ResetPuzzle()
    {
        Debug.Log("play me");
    }
}

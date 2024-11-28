using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimate))]
public class PersonController : MonoBehaviour {
    public CinemachineVirtualCameraBase mPlayerCamera = null;
    protected bool mCanMove = true;
    protected bool mReset = false;
    protected PlayerAnimate playerAnimate;
    protected GameManager gameManager;

    protected virtual void Awake() {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.gameManager.IsBusy = false;
        this.playerAnimate = this.GetComponent<PlayerAnimate>();
    }

    protected virtual void PlayerMove() {
    }
    
    public void SetInputEnabled(bool v) {
        this.mCanMove = v;
        this.mReset = false;
    }
}

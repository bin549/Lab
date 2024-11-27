using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PersonController : MonoBehaviour {
    public CinemachineVirtualCameraBase mPlayerCamera = null;
    protected bool mCanMove = true;
    protected bool mReset = false;

    protected virtual void Awake() {
    }

    protected virtual void PlayerMove() {
        
    }
    
    public void SetInputEnabled(bool v) {
        this.mCanMove = v;
        this.mReset = false;
    }
}

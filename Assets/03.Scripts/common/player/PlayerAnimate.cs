using System;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour{
    private Animator animator;

    private void Awake() {
        this.animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void UpdateSpeed(float speed) {
        this.animator.SetFloat("speed", speed);
    }
}

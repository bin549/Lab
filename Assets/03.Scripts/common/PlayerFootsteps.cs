using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {
    private AudioSource footstepSound;
    [SerializeField] private AudioClip[] footstepClip;
    private CharacterController characterController;
    public float volume_Min, volume_Max;
    private float accumulatedDistance;
    [SerializeField] private float wallSpeedDistance;

    private void Awake() {
        this.footstepSound = GetComponent<AudioSource>();
        this.characterController = GetComponentInParent<CharacterController>();
    }

    private void Update() {
        this.CheckToPlayFootstepSound();
    }

    private void CheckToPlayFootstepSound() {
        if (this.characterController.velocity.sqrMagnitude > 0) {
            this.accumulatedDistance += Time.deltaTime;
            if (this.accumulatedDistance > wallSpeedDistance) {
                this.footstepSound.volume = Random.Range(volume_Min, volume_Max);
                this.footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                this.footstepSound.Play();
                this.accumulatedDistance = 0f;
            }
        }
    }
}